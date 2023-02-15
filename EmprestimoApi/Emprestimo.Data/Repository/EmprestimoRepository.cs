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

        public async Task<IEnumerable<Cliente>> BuscaCpf(Cliente cliente)
        {
            var clientes = await _context.Clientes.Where(c => c.Cpf == cliente.Cpf).ToListAsync();
            return clientes;
        }

        public Cliente BuscarPorId(int id)
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

        public Emprestimo NovoEmprestimo(double ValorEmprestimo, int QuantidadeParcelas, int id)
        {
            var emprestimo = new Emprestimo();
            var cliente = _context.Clientes.FirstOrDefault(x => x.Id == id);

            emprestimo.ValorEmprestimo = ValorEmprestimo;
            emprestimo.QuantidadeParcelas = QuantidadeParcelas;

            var valorTotalComJuros = emprestimo.valorTotalComJuros(ValorEmprestimo);
            emprestimo.valorTotal = valorTotalComJuros;

            var valorDaParcela = emprestimo.ValorParcela(valorTotalComJuros, QuantidadeParcelas);
            emprestimo.ValorDaParcela = valorDaParcela;

            emprestimo.Cliente = cliente;

            emprestimo.Cliente.SaldoAtual += emprestimo.ValorEmprestimo;

            _context.Emprestimos.Add(emprestimo);
            _context.SaveChanges();

            return emprestimo;
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

        public Emprestimo ObterPorId(int id)
        {
            try
            {
                var emprestimo = _context.Emprestimos.Include(c => c.Cliente)
              .Where(x => x.Id == id).FirstOrDefault(X => X.Id == id);

                return emprestimo;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public async Task<IEnumerable<Cliente>> filtroPorNome(string cliente)
        {
            var query = await _context.Clientes.Where(c => c.Nome.Contains(cliente)).ToListAsync();

            return query;
        }

    }
}
