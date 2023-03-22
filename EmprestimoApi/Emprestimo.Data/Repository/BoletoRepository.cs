using CredEmprestimo.Business.Interface;
using CredEmprestimo.Business.Models;
using CredEmprestimo.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CredEmprestimo.Data.Repository
{
    public class BoletoRepository : IBoletoRepository
    {
        private readonly DataContext _context;
        private readonly IEmprestimoRepository _emprestimoRepository;

        public BoletoRepository(DataContext context, IEmprestimoRepository emprestimoRepository)
        {
            _context = context;
            _emprestimoRepository = emprestimoRepository;
        }

        public BoletoEmprestimo GerarBoleto(int id)
        {
            var emprestimo = _emprestimoRepository.PesquisarEmprestimo(id);

            var boleto = new BoletoEmprestimo();

            var dataVencimentoParcela = emprestimo.DataAquisicaoEmprestimo;
            var dataParcela = DateTime.Now;
            var numeroParcela = 1;

            for (int i = 0; i < emprestimo.QuantidadeParcelas; i++)
            {
                dataVencimentoParcela = dataParcela;

                boleto = new BoletoEmprestimo
                {
                    Id = 0,
                    NumeroParcela = numeroParcela + i,
                    EmprestimoId = emprestimo.Id,
                    ValorDaParcela = emprestimo.ValorDaParcela,
                    DataDePagamento = dataVencimentoParcela.AddDays(30)
                };

                dataParcela = boleto.DataDePagamento;
                _context.BoletoEmprestimo.Add(boleto);
            }

            _context.SaveChanges();
            return boleto;
        }

        public double PagarParcelaVencida(int id)
        {
            var data = _context.BoletoEmprestimo.Include(d => d.Emprestimo).FirstOrDefault
                (x => x.Id == id);

            var vencimentoBoleto = data.DataDePagamento.Day;
            var dataAtual = DateTime.Now.Day;

            var diasCorridos = dataAtual - vencimentoBoleto;
            var valorTotal = PagarParcelaVencida(data.ValorDaParcela, diasCorridos);

            return valorTotal;

        }

        public BoletoEmprestimo PagarUmaParcela(int id, int numeroDaParcela)
        {
            var parcela = PesquisarBoleto(id, numeroDaParcela);

            var emprestimo = _emprestimoRepository.DetalhesEmprestimo(parcela.EmprestimoId);

            emprestimo.Cliente.SaldoAtual -= emprestimo.ValorDaParcela;

            _context.BoletoEmprestimo.Remove(parcela);
            _context.Cliente.Update(emprestimo.Cliente);
            _context.SaveChanges();
            return parcela;
        }

        public BoletoEmprestimo PesquisarBoleto(int id, int numeroParcela)
        {
            var parcela = _context.BoletoEmprestimo.FirstOrDefault(x => x.EmprestimoId == id && x.NumeroParcela == numeroParcela);
            return parcela;
        }

        private double PagarParcelaVencida(double valorParcela, int diasEmAtraso)
        {

            double jurosAposVencimento = 3.3 / 100.00;
            double valorComJuros = diasEmAtraso + (jurosAposVencimento * diasEmAtraso);

            double multaAposvencimento = 200 / 100.00;
            double valorAjustado = valorParcela + multaAposvencimento;

            double totalJuros = valorAjustado + valorComJuros;
            return totalJuros;

        }
    }
}
