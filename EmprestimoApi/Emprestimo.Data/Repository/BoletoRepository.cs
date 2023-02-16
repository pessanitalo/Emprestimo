using CredEmprestimo.Business.Interface;
using CredEmprestimo.Business.Models;
using CredEmprestimo.Data.Context;

namespace CredEmprestimo.Data.Repository
{
    public class BoletoRepository : IBoletoRepository
    {
        private readonly DataContext _context;

        public BoletoRepository(DataContext context)
        {
            _context = context;
        }

        public BoletoEmprestimo GerarBoleto(int id)
        {
            var emprestimo = _context.Emprestimos.FirstOrDefault(x => x.Id == id);

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
    }
}
