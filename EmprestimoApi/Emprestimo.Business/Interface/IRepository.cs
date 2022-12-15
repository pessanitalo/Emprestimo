using CredEmprestimo.Business.Models;

namespace CredEmprestimo.Business.Interface
{
    public interface IRepository
    {
        Cliente Create(Cliente cliente);
        Task<IEnumerable<Emprestimo>> ListarEmprestimos();
        Task<IEnumerable<Cliente>> ListaClientes();
        Task<bool> BuscaCpf(Cliente cliente);
        Cliente BuscarPorId(int id);
    }
}
