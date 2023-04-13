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
        private readonly IMapper _mapper;

        public EmprestimoController(IEmprestimoRepository repository, IMapper mapper)
        {
            _emprestimoRepository = repository;
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

        [HttpPost]
        public IActionResult emprestimoDto(EmprestimoViewModel emprestimodto)
        {
            try
            {
                var emprestimo = _mapper.Map<Emprestimo>(emprestimodto);
                var result = _emprestimoRepository.NovoEmprestimo(emprestimo.ValorEmprestimo, emprestimo.QuantidadeParcelas, emprestimo.ClienteId);

                return Ok(result);
            }
            catch { return StatusCode(500, "Falha interna no servidor."); }
        }
    }
}
