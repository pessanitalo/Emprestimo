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

        public async Task<PageList<Cliente>> ListaClientes(PageParams pageParams)
        {
            var clientes = await _clienteRepository.ListaClientes(pageParams);

            return clientes;

        }
        public Task<PageList<Cliente>> Busca(PageParams pageParams, string cpf)
        {
            var busca = _clienteRepository.Busca(pageParams, cpf);
            return busca;
        }

        public Cliente Create(Cliente cliente)
        {
            var novocliente = _clienteRepository.Create(cliente);

            return novocliente;
        }

        public Cliente DetalhesCliente(int id)
        {
            var detalhe = _clienteRepository.DetalhesCliente(id);

            return detalhe;
        }

    }
}
