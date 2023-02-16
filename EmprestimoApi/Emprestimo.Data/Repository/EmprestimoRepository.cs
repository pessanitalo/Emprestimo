using CredEmprestimo.Business.Interface;
using CredEmprestimo.Business.Models;
using CredEmprestimo.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CredEmprestimo.Data.Repository
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly DataContext _context;

        public EmprestimoRepository(DataContext context)
        {
            _context = context;
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
        public Emprestimo NovoEmprestimo(double ValorEmprestimo, int QuantidadeParcelas, int id)
        {
            var emprestimo = new Emprestimo();
            var cliente = _context.Clientes.FirstOrDefault(x => x.Id == id);

            emprestimo.ValorEmprestimo = ValorEmprestimo;
            emprestimo.QuantidadeParcelas = QuantidadeParcelas;

            var valorTotalComJuros = emprestimo.valorTotalComJuros(ValorEmprestimo);
            emprestimo.valorTotal = valorTotalComJuros;
            emprestimo.DataAquisicaoEmprestimo = DateTime.Now;

            var valorDaParcela = emprestimo.ValorParcela(valorTotalComJuros, QuantidadeParcelas);
            emprestimo.ValorDaParcela = valorDaParcela;
            emprestimo.Cliente = cliente;
            emprestimo.Cliente.SaldoAtual += emprestimo.ValorEmprestimo;

            _context.Emprestimos.Add(emprestimo);
            _context.SaveChanges();

            return emprestimo;
        }
    }
}
