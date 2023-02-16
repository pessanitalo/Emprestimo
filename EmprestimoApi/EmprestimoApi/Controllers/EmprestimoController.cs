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
        public async Task<IEnumerable<Emprestimo>> get()
        {
            return await _emprestimoRepository.ListarEmprestimos();
        }

        [HttpGet("{id}")]
        public IActionResult get(int id)
        {
            try
            {
                var consulta = _emprestimoRepository.ObterPorId(id);
                return Ok(consulta);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
         
        }

        [HttpPost]
        public IActionResult emprestimoDto(EmprestimoViewModel emprestimodto)
        {
            var emprestimo = _mapper.Map<Emprestimo>(emprestimodto);
            var result = _emprestimoRepository.NovoEmprestimo(emprestimo.ValorEmprestimo, emprestimo.QuantidadeParcelas, emprestimo.ClienteId);

            return Ok(result);
        }
    }
}
