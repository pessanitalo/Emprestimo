using CredEmprestimo.Business.Interface;
using CredEmprestimo.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace CredEmprestimo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly IRepository _repository;

        public ClienteController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("filtro/{nome?}")]
        public async Task<IEnumerable<Cliente>> filtro(string? nome)
        {

            if (!string.IsNullOrEmpty(nome))
            {
                return await _repository.filtroPorNome(nome);
            }

            return await _repository.ListaClientes();

        }

        [HttpGet]
        [Route("getId/{id}")]
        public Cliente get(int id)
        {
            var consulta = _repository.BuscarPorId(id);

            return consulta;
        }

        [HttpPost]
        public IActionResult create(Cliente cliente)
        {
            var result = _repository.Create(cliente);

            return Ok(result);
        }
    }
}
