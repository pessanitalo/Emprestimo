using CredEmprestimo.Business.Interface;
using CredEmprestimo.Business.Models;
using CredEmprestimo.Business.Models.Utils;

namespace CredEmprestimo.Business.Services
{
    public class ClienteServices : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteServices(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Cliente Create(Cliente cliente)
        {
            var novocliente = _clienteRepository.Create(cliente);
            return novocliente;
        }

        public async Task<bool> validar(Cliente cliente)
        {
            try
            {
                IList<Cliente> retorno = (IList<Cliente>)await _clienteRepository.Validar(cliente.Cpf);
                if (retorno.Count > 0) return true;
                return false;

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao verificar se usuário existe. Erro: {ex.Message}");
            }

        }

        public Cliente DetalhesCliente(int id)
        {
            var detalhe = _clienteRepository.DetalhesCliente(id);
            return detalhe;
        }

        public decimal VerificarSaldo(int id)
        {
            var cliente =  _clienteRepository.VerificarSaldo(id);
            return cliente;
        }

        public async Task<PagedResult<Cliente>> ListaCliente(int pageSize, int pageIndex, string cpf)
        {
            return await _clienteRepository.ListaCliente(pageSize, pageIndex, cpf);
        }

        public Task<PageList<Cliente>> Paginacao(PageParams pageParams, string cpf)
        {
            var cliente = _clienteRepository.Paginacao(pageParams,cpf);
            return cliente;
        }
    }
}
