using CredEmprestimo.Business.Interface;
using CredEmprestimo.Business.Models;
using CredEmprestimo.Business.Models.Utils;
using CredEmprestimo.Data.Context;
using CredEmprestimo.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Collections;


namespace CredEmprestimo.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DataContext _context;

        public ClienteRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<PageList<Cliente>> Busca(PageParams pageParams, string cpf)
        {
            var cliente = _context.Clientes.Where(c => c.Cpf.Contains(cpf));
            return await PageList<Cliente>.CreateAsync(cliente, pageParams.PageNumber, pageParams.pageSize);

        }
        public Cliente DetalhesCliente(int id)
        {
            var consulta = _context.Clientes.
               FirstOrDefault(X => X.ClienteId == id);

            return consulta;
        }
        public Cliente Create(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return cliente;
        }
        public async Task<IEnumerable> Validar(string cpf)
        {
            var clientes = await _context.Clientes.Where(c => c.Cpf == cpf).ToListAsync();
            return clientes;
        }

        public decimal VerificarSaldo(int id)
        {
            var cliente = _context.Emprestimos.FirstOrDefault(x => x.EmprestimoId == id);
            var saldo = _context.Clientes.FirstOrDefault(x => x.ClienteId == cliente.ClienteId);

            return saldo.SaldoAtual;
        }

        public async Task<PagedResult<Cliente>> ListaCliente(int pageSize, int pageIndex, string cpf)
        {
            var cclientesQuery = _context.Clientes.AsQueryable();

            cclientesQuery = cclientesQuery
                    .WhereIf(!string.IsNullOrEmpty(cpf), p => p.Cpf == cpf);

            var catalog = await cclientesQuery.AsNoTrackingWithIdentityResolution()
                                      .Skip(pageSize * (pageIndex - 1))
                                      .Take(pageSize).ToListAsync();

            return new PagedResult<Cliente>()
            {
                List = catalog,
                PageIndex = pageIndex,
                PageSize = pageSize,
            };
        }
    }
}
