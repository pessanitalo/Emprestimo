using AutoMapper;
using CredEmprestimo.Business.Interface;
using CredEmprestimo.Business.Models;
using CredEmprestimo.Business.Models.Utils;
using CredEmprestimoApi.Extensions;
using CredEmprestimoApi.ViewlModews;
using Microsoft.AspNetCore.Mvc;

namespace CredEmprestimoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoletoController : ControllerBase
    {

        private readonly IBoletoService _boletoService;
        private readonly IMapper _mapper;

        public BoletoController(IBoletoService boletoService, IMapper mapper)
        {
            _boletoService = boletoService;
            _mapper = mapper;
        }

        [HttpPost("pagarparcela")]
        public IActionResult PagarParcela([FromBody] PagarParcela pagarParcela)
        {
            try
            {
                if (_boletoService.ValidarSaldo(pagarParcela.ClienteId)) return BadRequest("Saldo Insuficiente");
                
                var parcela = _boletoService.PagarUmaParcela(pagarParcela.Id, pagarParcela.numeroParcela);
                return Ok(parcela);
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<PagarParcela>>("Falha interna no servidor"));
            }
        }

        [HttpGet("detalhesparcela/{id:int}")]
        public async Task<IActionResult> VisualizarParcela(int id)
        {
            try
            {
                var parcelas = await _boletoService.VisualizarParcela(id);
                return Ok(parcelas);
            }
            catch { return StatusCode(500, "Falha interna no servidor."); }

        }

        [HttpGet]
        [Route("pagination/{id:int}")]
        public async Task<IActionResult> pagination(int id,[FromQuery] PageParams pageParams)
        {
            try
            {
                var clientes = await _boletoService.ListaBoletos(id,pageParams);

                var filtro = _mapper.Map<PageList<BoletoViewModel>>(clientes);
                pagination(clientes, filtro);

                return Ok(clientes);
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<BoletoViewModel>>("Falha interna no servidor"));
            }

        }

        private void pagination<T, U>(PageList<T> clientes, PageList<U> filtro)
        {
            filtro.CurrentPage = clientes.CurrentPage;
            filtro.TotalPages = clientes.TotalPages;
            filtro.PageSize = clientes.PageSize;
            filtro.TotalCount = clientes.TotalCount;

            Response.AddPagination(filtro.CurrentPage, filtro.PageSize, filtro.TotalCount, filtro.TotalPages);
        }
    }
}
