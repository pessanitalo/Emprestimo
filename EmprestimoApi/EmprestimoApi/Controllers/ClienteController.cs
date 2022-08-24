﻿using EmprestimoApi.DataContext;
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
        //teste 123123
         [HttpGet]
        public IActionResult get(string nomeFiltro)
        {
            var query = _context.Clientes.ToList();

            if (!string.IsNullOrEmpty(nomeFiltro))
            {
                query = _context.Clientes.Where(c => c.Nome.Contains("italo")).ToList();
            }
            return Ok(query);
        }

        [HttpGet("{id}")]
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

            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return Ok(cliente);
        }
    }
}
