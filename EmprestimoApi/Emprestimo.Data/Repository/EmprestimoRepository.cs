using CredEmprestimo.Business.Interface;
using CredEmprestimo.Business.Models;
using CredEmprestimo.Data.Context;
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
            .Where(x => x.Id == id).FirstOrDefault(X => X.Id == id);

            return emprestimo;
        }
        public Emprestimo NovoEmprestimo(double ValorEmprestimo, int QuantidadeParcelas, int id)
        {
            var emprestimo = new Emprestimo();
            var cliente = _clienteRepository.PesquisarCliente(id);

            emprestimo.emprestimo(ValorEmprestimo, QuantidadeParcelas,  cliente);

            _context.Emprestimos.Add(emprestimo);
            _context.SaveChanges();

            return emprestimo;
        }

        //private static void Emprestimo(double ValorEmprestimo, int QuantidadeParcelas, Emprestimo emprestimo, Cliente cliente)
        //{
        //    emprestimo.ValorEmprestimo = ValorEmprestimo;
        //    emprestimo.QuantidadeParcelas = QuantidadeParcelas;

        //    var valorTotalComJuros = emprestimo.valorTotalComJuros(ValorEmprestimo);
        //    emprestimo.valorTotal = valorTotalComJuros;
        //    emprestimo.DataAquisicaoEmprestimo = DateTime.Now;

        //    var valorDaParcela = emprestimo.ValorParcela(valorTotalComJuros, QuantidadeParcelas);
        //    emprestimo.ValorDaParcela = valorDaParcela;
        //    emprestimo.Cliente = cliente;
        //    emprestimo.Cliente.SaldoAtual += emprestimo.ValorEmprestimo;
        //}

        public Emprestimo PesquisarEmprestimo(int id)
        {
            var emprestimo = _context.Emprestimos.FirstOrDefault(X => X.Id == id);
            return emprestimo;
        }
    }
}
