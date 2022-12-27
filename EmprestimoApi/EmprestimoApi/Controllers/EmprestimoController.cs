using CredEmprestimo.Business.Interface;
using CredEmprestimo.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmprestimoController : ControllerBase
    {

        private readonly IRepository _repository;

        public EmprestimoController(IRepository repository)
        {
            _repository = repository;
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

        [HttpPost]
        public IActionResult Create(Emprestimo emprestimo)
        {
            var result = _repository.NovoEmprestimo(emprestimo.ValorEmprestimo,emprestimo.QuantidadeParcelas, emprestimo.Id);

            return Ok(result);
        }

    }
}
