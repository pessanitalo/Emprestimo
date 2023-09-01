using CredEmprestimo.Business.Interface;
using CredEmprestimo.Business.Models;
using CredEmprestimo.Business.Models.Utils;
using CredEmprestimo.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CredEmprestimo.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DataContext _context;

        public ClienteRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<PageList<Cliente>> ListaClientes(PageParams pageParams)
        {
            IQueryable<Cliente> query = _context.Clientes;

            return await PageList<Cliente>.CreateAsync(query, pageParams.PageNumber, pageParams.pageSize);
        }

        public async Task<PageList<Cliente>> Busca(PageParams pageParams, string cpf)
        {
            var cliente = _context.Clientes.Where(c => c.Cpf.Contains(cpf));
            return await PageList<Cliente>.CreateAsync(cliente, pageParams.PageNumber, pageParams.pageSize);

        }
        public async Task<Cliente> BuscaCpf(string cpf)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Cpf == cpf);
            return cliente;
        }
        public Cliente DetalhesCliente(int id)
        {
            var consulta = _context.Clientes.Include(c => c.Emprestimo)
               .Where(x => x.Id == id).FirstOrDefault(X => X.Id == id);

            return consulta;
        }
        public Cliente Create(Cliente cliente)
        {
            //var clientes = _context.Clientes.Where(c => c.Cpf == cliente.Cpf).ToList();
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return cliente;
        }
        public Cliente PesquisarCliente(int id)
        {
            var cliente = _context.Clientes
             .FirstOrDefault(X => X.Id == id);
            return cliente;
        }


    }
}
