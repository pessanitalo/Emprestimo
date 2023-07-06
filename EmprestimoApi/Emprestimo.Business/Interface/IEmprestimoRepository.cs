using CredEmprestimo.Business.Models;

namespace CredEmprestimo.Business.Interface
{
    public interface IEmprestimoRepository
    {
        Task<IEnumerable<Emprestimo>> ListarEmprestimos();
        Emprestimo DetalhesEmprestimo(int id);
        Emprestimo PesquisarEmprestimo(int id);
        Emprestimo NovoEmprestimo(decimal ValorEmprestimo, int QuantidadeParcelas, int id);
    }
}
