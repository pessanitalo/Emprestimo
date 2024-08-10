using AutoMapper;
using CredEmprestimo.Business.Interface;
using CredEmprestimo.Business.Models;
using CredEmprestimo.Business.Models.Utils;
using CredEmprestimoApi.Extensions;
using CredEmprestimoApi.ViewlModews;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmprestimoController : ControllerBase
    {
        private readonly IEmprestimoService _emprestimoService;
        private readonly IBoletoService _boletoService;
        private readonly IMapper _mapper;

        public EmprestimoController(IEmprestimoService emprestimoService,
                    IBoletoService boletoService, IMapper mapper)
        {

            _emprestimoService = emprestimoService;
            _boletoService = boletoService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult EmprestimoDto([FromBody]EmprestimoViewModel emprestimodto)
        {
            try
            {
                var emprestimo = _mapper.Map<Emprestimo>(emprestimodto);
                var result = _emprestimoService.NovoEmprestimo(emprestimo.ValorEmprestimo, emprestimo.QuantidadeParcelas,
                              emprestimo.ClienteId);
                var boleto = _boletoService.GerarBoleto(result.EmprestimoId);

                return Ok(result);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("pagination")]
        public async Task<IActionResult> filtro([FromQuery] PageParams pageParams)
        {
            try
            {            
                var clientes = await _emprestimoService.ListaEmprestimo(pageParams);
                var filtro = _mapper.Map<PageList<EmprestimoViewModel>>(clientes);
                pagination(clientes, filtro);
                return Ok(clientes);
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Cliente>>("Falha interna no servidor"));
            }

        }

        [HttpGet("list")]
        public async Task<IActionResult> list()
        {
            try
            {
                var list = await _emprestimoService.ListarEmprestimos();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("detalhes/{id:int}")]
        public IActionResult Detalhes(int id)
        {
            try
            {
                var consulta = _emprestimoService.DetalhesEmprestimo(id);
                if (consulta == null) return NotFound(new ResultViewModel<Emprestimo>("Emprestimo não encontrado"));
                return Ok(consulta);
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Emprestimo>>("Falha interna no servidor"));
            }
        }

        [HttpPost("simular-emprestimo")]
        public IActionResult SimularEmprestimoDto(EmprestimoViewModel emprestimodto)
        {
            try
            {
                var emprestimo = _mapper.Map<Emprestimo>(emprestimodto);
                var result = _emprestimoService.SimularEmprestimo(emprestimo.ValorEmprestimo, emprestimo.QuantidadeParcelas);

                return Ok(result);
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Emprestimo>>("Falha interna no servidor"));
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
