using CredEmprestimo.Business.Interface;
using CredEmprestimo.Business.Models;
using CredEmprestimo.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CredEmprestimo.Data.Repository
{
    public class EmprestimoRepository : IRepository
    {
        private readonly DataContext _context;

        public EmprestimoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> BuscaCpf(Cliente cliente)
        {
            var clientes =await _context.Clientes.Where(c => c.Cpf == cliente.Cpf).ToListAsync();

            if (clientes.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
           
        }

        public Cliente BuscarPorId(int id)
        {
            var consulta = _context.Clientes.Include(c => c.Emprestimo)
                .Where(x => x.Id == id).FirstOrDefault(X => X.Id == id);

            return consulta;
        }

        public Cliente Create(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            return cliente;
        }

        public async Task<IEnumerable<Cliente>> ListaClientes()
        {
            var list = await _context.Clientes.ToListAsync();
            return list;
        }

        public async Task<IEnumerable<Emprestimo>> ListarEmprestimos()
        {
            var list = await _context.Emprestimos.ToListAsync();
            return list;
        }
    }
}
