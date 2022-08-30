using EmprestimoApi.DataContext;
using EmprestimoApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmprestimoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly Context _context;

        public ClienteController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("filtro/{nome?}")]
        public Cliente[] filtro(string? nome)
        {
            var query = _context.Clientes.ToList();

            if (!string.IsNullOrEmpty(nome))
            {
                query = _context.Clientes.Where(c => c.Nome.Contains(nome)).ToList();
            }

            return query.ToArray();
        }

        [HttpGet]
        [Route("getId/{id}")]
        public Cliente get(int id)
        {
            //var cliente = _context.Clientes.FirstOrDefault(X => X.Id == id);
            //if (cliente == null) return BadRequest("Cliente não encontrado");

            var cliente = _context.Clientes
              .Include(p => p.Emprestimo)
                   .Where(p => p.Id == id);
            return cliente.FirstOrDefault();
        }

        [HttpPost]
        public IActionResult create(Cliente cliente)
        {
            if (cliente == null) return BadRequest();
            List<Cliente> clientes = _context.Clientes.Where(c => c.Cpf == cliente.Cpf).ToList();

            if (clientes.Count > 0)
            {
                return BadRequest("Cliente já cadastrado");
            }

            else
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
            }           
            return Ok(cliente);
        }
    }
}
