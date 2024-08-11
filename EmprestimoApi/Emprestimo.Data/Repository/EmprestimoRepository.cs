﻿using CredEmprestimo.Business.Interface;
using CredEmprestimo.Business.Models;
using CredEmprestimo.Business.Models.Utils;
using CredEmprestimo.Data.Context;
using CredEmprestimo.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CredEmprestimo.Data.Repository
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly DataContext _context;
        private readonly IClienteRepository _clienteRepository;


        public EmprestimoRepository(DataContext context, IClienteRepository clienteRepository)
        {
            _context = context;
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<Emprestimo>> ListarEmprestimos()
        {
            var list = await _context.Emprestimos.ToListAsync();
            return list;
        }

        public Emprestimo DetalhesEmprestimo(int id)
        {
            var emprestimo = _context.Emprestimos.Include(c => c.Cliente)
            .Where(x => x.EmprestimoId == id).FirstOrDefault(X => X.EmprestimoId == id);

            return emprestimo;
        }
        public Emprestimo SimularEmprestimo(decimal ValorEmprestimo, int QuantidadeParcelas)
        {
            var emprestimo = new Emprestimo(ValorEmprestimo, QuantidadeParcelas);
            emprestimo.SimularEmprestimo(ValorEmprestimo, QuantidadeParcelas);
            return emprestimo;
        }


        public Emprestimo NovoEmprestimo(decimal ValorEmprestimo, int QuantidadeParcelas, int id)
        {
            var emprestimo = new Emprestimo(ValorEmprestimo, QuantidadeParcelas);
            var cliente = _clienteRepository.DetalhesCliente(id);

            emprestimo.emprestimo(ValorEmprestimo, QuantidadeParcelas, cliente);

            _context.Emprestimos.Add(emprestimo);
            _context.SaveChanges();

            return emprestimo;
        }

        public async Task<PageList<Emprestimo>> ListaEmprestimo(PageParams pageParams)
        {
            IQueryable<Emprestimo> query = _context.Emprestimos;

            return await PageList<Emprestimo>.CreateAsync(query, pageParams.PageNumber, pageParams.pageSize);
        }

        public async Task<PagedResult<Emprestimo>> ListarEmprestimos(int pageSize, int pageIndex)
        {
            var emprestimosQuery = _context.Emprestimos.AsQueryable();

            var emprestimo = await emprestimosQuery.AsNoTrackingWithIdentityResolution()
                                      .Skip(pageSize * (pageIndex - 1))
                                      .Take(pageSize).ToListAsync();

            return new PagedResult<Emprestimo>()
            {
                List = emprestimo,
                PageIndex = pageIndex,
                PageSize = pageSize,
            };
        }
    }
}
