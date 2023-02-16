using CredEmprestimo.Business.Models;

namespace CredEmprestimo.Business.Interface
{
    public interface IClienteRepository
    {
        Cliente Create(Cliente cliente);
        Task<IEnumerable<Cliente>> ListaClientes();
        Task<IEnumerable<Cliente>> BuscaCpf(Cliente cliente);
        Task<IEnumerable<Cliente>> filtroPorNome(string cliente);
        Cliente BuscarPorId(int id);
    }
}
