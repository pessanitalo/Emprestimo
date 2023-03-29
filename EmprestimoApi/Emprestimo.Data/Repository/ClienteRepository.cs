using CredEmprestimo.Business.Interface;
using CredEmprestimo.Business.Models;
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

        public async Task<IEnumerable<Cliente>> ListaClientes()
        {
            var list = await _context.Clientes.ToListAsync();
            return list;
        }
        public async Task<IEnumerable<Cliente>> BuscaCpf(Cliente cliente)
        {
            var clientes = await _context.Clientes.Where(c => c.Cpf == cliente.Cpf).ToListAsync();
            return clientes;
        }

        public async Task<IEnumerable<Cliente>> filtroPorNome(string cliente)
        {
            var query = await _context.Clientes.Where(c => c.Nome.Contains(cliente)).ToListAsync();

            return query;
        }

        public Cliente DetalhesCliente(int id)
        {
            try
            {
                var consulta = _context.Clientes.Include(c => c.Emprestimo)
                  .Where(x => x.Id == id).FirstOrDefault(X => X.Id == id);

                if (consulta == null) throw new Exception("Não foi possível encontrar o cliente.");

                return consulta;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Cliente Create(Cliente cliente)
        {
            List<Cliente> clientes = _context.Clientes.Where(c => c.Cpf == cliente.Cpf).ToList();
            try
            {
                if (clientes.Count > 0) throw new Exception("Já existe um cliente com esse cpf");

                _context.Clientes.Add(cliente);
                _context.SaveChanges();

                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Cliente PesquisarCliente(int id)
        {
            try
            {
                var cliente = _context.Clientes
                 .FirstOrDefault(X => X.Id == id);

                if (cliente == null) throw new Exception("Não foi possível encontrar o cliente.");

                return cliente;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
