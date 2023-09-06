using CredEmprestimo.Business.Interface;
using CredEmprestimo.Business.Models;

namespace CredEmprestimo.Business.Services
{
    public class BoletoService : IBoletoService
    {
        private readonly IBoletoRepository _boletoRepository;
        private readonly IClienteService _clienteService;

        public BoletoService(IBoletoRepository boletoRepository, IClienteService clienteService)
        {
            _boletoRepository = boletoRepository;
            _clienteService = clienteService;
        }

        public BoletoEmprestimo GerarBoleto(int id)
        {
            var boletos = _boletoRepository.GerarBoleto(id);
            return boletos;
        }

        public BoletoEmprestimo PagarUmaParcela(int id, int numeroDaParcela)
        {
            try
            {
                var parcela = _boletoRepository.PagarUmaParcela(id, numeroDaParcela);
                return parcela;
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao verificar se usuário existe. Erro: {ex.Message}");
            }

        }

        public bool ValidarSaldo(int id)
        {
            var saldo = _clienteService.DetalhesCliente(id);
            var sal = saldo.SaldoAtual;
            var conta = saldo.Emprestimo.ValorDaParcela;

            if (sal < conta) return true;
            return false;
        }

        public List<BoletoEmprestimo> VisualizarParcela(int id)
        {
            var parcela = _boletoRepository.VisualizarParcela(id);
            return parcela;
        }
    }
}
