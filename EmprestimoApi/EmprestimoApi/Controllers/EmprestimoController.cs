﻿using CredEmprestimo.Business.Interface;
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
        public IActionResult get()
        {
            var ret = _repository.ListarEmprestimos();
            return Ok(ret);
        }

        //[HttpGet("{id}")]
        //public Emprestimo get(int id)
        //{
        //    //var emprestimo = _context.Emprestimos.Where( p => p.Id == id);
        //    //if (emprestimo == null) return BadRequest("Emprestimo não encontrado");

        //    //return Ok(emprestimo);

        //    IQueryable<Emprestimo> query = _context.Emprestimos;
        //    query = query.Include(p => p.Cliente)
        //        .Where(p => p.Id == id);
        //    return query.FirstOrDefault();
        //}

        //[HttpPost]
        //public IActionResult Create(Emprestimo emprestimo, int id)
        //{

        //    if (!ModelState.IsValid) return BadRequest();

        //    var cliente = _context.Clientes.FirstOrDefault(x => x.Id == id);

        //    var calc = emprestimo.ValorTotal(emprestimo.ValorEmprestimo);
        //    emprestimo.valorTotal = calc;

        //    var parcelas = emprestimo.ValorParcela(calc, emprestimo.QuantidadeParcelas);
        //    emprestimo.ValorDaParcela = parcelas;


        //    emprestimo.Cliente = cliente;

        //    emprestimo.Cliente.SaldoAtual += emprestimo.ValorEmprestimo;

        //    _context.Emprestimos.Add(emprestimo);
        //    _context.SaveChanges();

        //    return Ok("Ok");
        //}
    }
}
