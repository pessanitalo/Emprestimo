using CredEmprestimo.Business.Models;

namespace CredEmprestimo.Business.Interface
{
    public interface IEmprestimoService
    {
        Task<IEnumerable<Emprestimo>> ListarEmprestimos();
        Emprestimo DetalhesEmprestimo(int id);
        Emprestimo SimularEmprestimo(decimal ValorEmprestimo, int QuantidadeParcelas);
        Emprestimo NovoEmprestimo(decimal ValorEmprestimo, int QuantidadeParcelas, int id);
    }
}
