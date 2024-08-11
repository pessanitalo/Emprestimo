using AutoMapper;
using CredEmprestimo.Business.Interface;
using CredEmprestimo.Business.Models;
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
        [Route("listaEmprestimos")]
        public async Task<IActionResult> listarEmprestimos(int pageSize, int pageIndex)
        {

            var lista = await _emprestimoService.ListarEmprestimos(pageSize, pageIndex);
            return Ok(lista);
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

    }
}
