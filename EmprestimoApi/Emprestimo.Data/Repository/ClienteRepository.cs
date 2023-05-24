using CredEmprestimo.Business.Interface;
using CredEmprestimo.Business.Models;
using CredEmprestimo.Data.Context;
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

        public async Task<IEnumerable> ListaClientes()
        {
            var list = await _context.Clientes.ToListAsync();
            return list;
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

        public async Task<IEnumerable<Cliente>> filtroPorNome(string cpf)
        {
            var cliente = await _context.Clientes.Where(c => c.Cpf.Contains(cpf)).ToListAsync();
            return cliente;
        }

        public Cliente Create(Cliente cliente)
        {
            List<Cliente> clientes = _context.Clientes.Where(c => c.Cpf == cliente.Cpf).ToList();

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
