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

        private readonly IEmprestimoRepository _emprestimoRepository;
        private readonly IBoletoRepository _boletoRepository;
        private readonly IMapper _mapper;

        public EmprestimoController(IEmprestimoRepository emprestimoRepository, IBoletoRepository boletoRepository, IMapper mapper)
        {
            _emprestimoRepository = emprestimoRepository;
            _boletoRepository = boletoRepository;
            _mapper = mapper;
        }

        [HttpGet("list")]
        public async Task<IActionResult> list()
        {
            try
            {
                var list = await _emprestimoRepository.ListarEmprestimos();

                return Ok(list);
            }
            catch { return StatusCode(500, "Falha interna no servidor."); }
        }

        [HttpGet("detalhes/{id:int}")]
        public IActionResult Detalhes(int id)
        {
            try
            {
                var consulta = _emprestimoRepository.DetalhesEmprestimo(id);
                if (consulta == null) return NotFound(new ResultViewModel<Emprestimo>("Emprestimo não encontrado"));
                return Ok(consulta);
            }
            catch { return StatusCode(500, "Falha interna no servidor."); }
        }

        [HttpPost("simular-emprestimo")]
        public IActionResult SimularEmprestimoDto(EmprestimoViewModel emprestimodto)
        {
            try
            {
                var emprestimo = _mapper.Map<Emprestimo>(emprestimodto);
                var result = _emprestimoRepository.SimularEmprestimo(emprestimo.ValorEmprestimo, emprestimo.QuantidadeParcelas);

                return Ok(result);
            }
            catch { return StatusCode(500, "Falha interna no servidor."); }
        }

        [HttpPost]
        public IActionResult EmprestimoDto(EmprestimoViewModel emprestimodto)
        {
            try
            {
                var emprestimo = _mapper.Map<Emprestimo>(emprestimodto);
                var result = _emprestimoRepository.NovoEmprestimo(emprestimo.ValorEmprestimo, emprestimo.QuantidadeParcelas, emprestimo.ClienteId);
                var boleto = _boletoRepository.GerarBoleto(result.Id);

                return Ok(result);
            }
            catch { return StatusCode(500, "Falha interna no servidor."); }
        }
    }
}
