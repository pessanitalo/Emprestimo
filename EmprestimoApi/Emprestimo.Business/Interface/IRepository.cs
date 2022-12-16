using CredEmprestimo.Business.Models;

namespace CredEmprestimo.Business.Interface
{
    public interface IRepository
    {
        Cliente Create(Cliente cliente);
        Task<IEnumerable<Cliente>> ListaClientes();
        Task<IEnumerable<Cliente>> BuscaCpf(Cliente cliente);
        Cliente BuscarPorId(int id);

        //Emprestimos

        Task<IEnumerable<Emprestimo>> ListarEmprestimos();
        Emprestimo ObterPorId(int id);
        Emprestimo CreateEmprestimo(Emprestimo emprestimo, int id);
    }
}
