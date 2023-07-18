using CredEmprestimo.Business.Models;

namespace CredEmprestimo.Business.Interface
{
    public interface IEmprestimoRepository
    {
        Task<IEnumerable<Emprestimo>> ListarEmprestimos();
        Emprestimo DetalhesEmprestimo(int id);
        Emprestimo PesquisarEmprestimo(int id);
        Emprestimo SimularEmprestimo(decimal ValorEmprestimo, int QuantidadeParcelas);
        Emprestimo NovoEmprestimo(decimal ValorEmprestimo, int QuantidadeParcelas, int id);
    }
}
