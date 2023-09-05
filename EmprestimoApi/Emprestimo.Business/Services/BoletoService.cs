using CredEmprestimo.Business.Interface;
using CredEmprestimo.Business.Models;


namespace CredEmprestimo.Business.Services
{
    public class BoletoService : IBoletoService
    {
        private readonly IBoletoRepository _boletoRepository;

        public BoletoService(IBoletoRepository boletoRepository)
        {
            _boletoRepository = boletoRepository;
        }

        public BoletoEmprestimo GerarBoleto(int id)
        {
            var boletos = _boletoRepository.GerarBoleto(id);
            return boletos;
        }

        public BoletoEmprestimo PagarUmaParcela(int id, int numeroDaParcela)
        {
            var parcela = _boletoRepository.PagarUmaParcela(id,numeroDaParcela);
            return parcela;
        }

        public List<BoletoEmprestimo> VisualizarParcela(int id)
        {
            var parcela = _boletoRepository.VisualizarParcela(id);
            return parcela;
        }
    }
}
