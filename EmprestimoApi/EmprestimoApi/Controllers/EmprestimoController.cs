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

        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public EmprestimoController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("list")]
        public async Task<IEnumerable<Emprestimo>> get()
        {
            return await _repository.ListarEmprestimos();
        }

        [HttpGet("{id}")]
        public Emprestimo get(int id)
        {
            var consulta = _repository.ObterPorId(id);
            return consulta;
        }

        //[HttpPost]
        //public IActionResult Create(Emprestimo emprestimo)
        //{
        //    var result = _repository.NovoEmprestimo(emprestimo.ValorEmprestimo,emprestimo.QuantidadeParcelas, emprestimo.ClienteId);

        //    return Ok(result);
        //}

        [HttpPost]
        public IActionResult emprestimoDto(EmprestimoViewModel emprestimodto)
        {
            var emprestimo = _mapper.Map<Emprestimo>(emprestimodto);
            var result = _repository.NovoEmprestimo(emprestimo.ValorEmprestimo, emprestimo.QuantidadeParcelas, emprestimo.ClienteId);

            return Ok(result);
        }

    }
}
