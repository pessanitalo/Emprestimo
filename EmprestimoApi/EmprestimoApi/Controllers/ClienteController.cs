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

        [HttpGet("list")]
        public async Task<IEnumerable<Cliente>> get()
        {
            return await _repository.ListaClientes();
        }

        //[HttpGet]
        //[Route("filtro/{nome?}")]
        //public Cliente[] filtro(string? nome)
        //{
        //    var query = _context.Clientes.ToList();

        //    if (!string.IsNullOrEmpty(nome))
        //    {
        //        query = _context.Clientes.Where(c => c.Nome.Contains(nome)).ToList();
        //    }

        //    return query.ToArray();
        //}

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
