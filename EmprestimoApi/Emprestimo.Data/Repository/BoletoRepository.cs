using CredEmprestimo.Business.Interface;
using CredEmprestimo.Business.Models;
using CredEmprestimo.Business.Models.Utils;
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
            var emprestimo = _emprestimoRepository.DetalhesEmprestimo(id);
            var boleto = new BoletoEmprestimo();
            var dataVencimentoParcela = emprestimo.DataAquisicaoEmprestimo;
            var dataParcela = DateTime.Now;
            var numeroParcela = 1;

            for (int i = 0; i < emprestimo.QuantidadeParcelas; i++)
            {
                dataVencimentoParcela = dataParcela;

                boleto = new BoletoEmprestimo
                {
                    BoletoId = 0,
                    NumeroParcela = numeroParcela + i,
                    EmprestimoId = emprestimo.EmprestimoId,
                    ValorDaParcela = emprestimo.ValorDaParcela,
                    DataDePagamento = dataVencimentoParcela.AddDays(30)
                };

                dataParcela = boleto.DataDePagamento;
                _context.BoletoEmprestimo.Add(boleto);
            }

            _context.SaveChanges();
            return boleto;
        }

        public async Task<PageList<BoletoEmprestimo>> ListaBoletos(int id,PageParams pageParams)
        {
            var parcelas =  _context.BoletoEmprestimo.Where(x => x.EmprestimoId == id);

            return await PageList<BoletoEmprestimo>.CreateAsync(parcelas, pageParams.PageNumber, pageParams.pageSize);
        }

        //public async Task<PagedResult<BoletoEmprestimo>> ListaBoletos(int pageSize, int pageIndex)
        //{
        //    var boletosQuery = _context.BoletoEmprestimo.AsQueryable();


        //    var boletos = await boletosQuery.AsNoTrackingWithIdentityResolution()
        //                              .Skip(pageSize * (pageIndex - 1))
        //                              .Take(pageSize).ToListAsync();

        //    return new PagedResult<BoletoEmprestimo>()
        //    {
        //        List = boletos,
        //        PageIndex = pageIndex,
        //        PageSize = pageSize,
        //    };
        //}

        public BoletoEmprestimo PagarUmaParcela(int id, int numeroDaParcela)
        {
            var parcela = PesquisarParcela(id, numeroDaParcela);

            var emprestimo = _emprestimoRepository.DetalhesEmprestimo(parcela.EmprestimoId);

            emprestimo.Cliente.SaldoAtual -= emprestimo.ValorDaParcela;

            _context.BoletoEmprestimo.Remove(parcela);
            _context.Clientes.Update(emprestimo.Cliente);
            _context.SaveChanges();
            return parcela;
        }

        public BoletoEmprestimo PesquisarParcela(int id, int numeroParcela)
        {
            var parcela = _context.BoletoEmprestimo.FirstOrDefault(x => x.EmprestimoId == id && x.NumeroParcela == numeroParcela);
            return parcela;
        }
        public async Task <IEnumerable<BoletoEmprestimo>> VisualizarParcela(int id)
        {
            var parcela = await _context.BoletoEmprestimo.Where(x => x.EmprestimoId == id).ToListAsync();
            return parcela.ToList();
        }
    }
}
