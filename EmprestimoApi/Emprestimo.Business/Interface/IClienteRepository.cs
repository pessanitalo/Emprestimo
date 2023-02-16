using CredEmprestimo.Business.Models;

namespace CredEmprestimo.Business.Interface
{
    public interface IClienteRepository
    {
        Cliente Create(Cliente cliente);
        Task<IEnumerable<Cliente>> ListaClientes();
        Task<IEnumerable<Cliente>> BuscaCpf(Cliente cliente);
        Task<IEnumerable<Cliente>> filtroPorNome(string cliente);
        Cliente DetalhesCliente(int id);
        Cliente PesquisarCliente(int id);
    }
}
