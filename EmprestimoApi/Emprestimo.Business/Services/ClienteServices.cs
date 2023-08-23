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

        public async Task<IEnumerable<Cliente>> filtroPorNome(string cliente)
        {
            var clientes = await _clienteRepository.filtroPorNome(cliente);

            return clientes;
        }

        public async Task<PageList<Cliente>> ListaClientes(PageParams pageParams)
        {
            var clientes = await  _clienteRepository.ListaClientes(pageParams);

            return clientes; 
         
        }
    }
}
