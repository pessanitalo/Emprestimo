using CredEmprestimo.Business.Interface;
using CredEmprestimo.Business.Models;
using CredEmprestimo.Business.Models.Utils;

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

        public async Task<PageList<BoletoEmprestimo>> ListaBoletos(int id, PageParams pageParams)
        {
            var boletos = await _boletoRepository.ListaBoletos(id, pageParams);

            return boletos;
        }

        //public async Task<PagedResult<BoletoEmprestimo>> ListaBoletos(int pageSize, int pageIndex)
        //{
        //    return await _boletoRepository.ListaBoletos(pageSize, pageIndex);
        //}

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

        public bool ValidarSaldo(PagarParcela pagarParcela)
        {
            var detalhesCliente = _clienteService.DetalhesCliente(pagarParcela.ClienteId);
            var saldo = detalhesCliente.SaldoAtual;
            var boletoParcela = _boletoRepository.PesquisarParcela(pagarParcela.EmprestimoId, pagarParcela.numeroParcela);
            if (saldo < boletoParcela.ValorDaParcela) return true;
            return false;
        }

        public async Task<IEnumerable<BoletoEmprestimo>> VisualizarParcela(int id)
        {
            var parcela = await _boletoRepository.VisualizarParcela(id);
            return parcela;
        }

    }
}
