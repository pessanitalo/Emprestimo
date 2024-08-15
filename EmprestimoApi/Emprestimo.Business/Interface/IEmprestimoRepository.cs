using CredEmprestimo.Business.Models;

namespace CredEmprestimo.Business.Interface
{
    public interface IEmprestimoRepository
    {
        Task<IEnumerable<Emprestimo>> ListarEmprestimos();
        Task<PagedResult<Emprestimo>> ListarEmprestimos(int pageSize, int pageIndex);
        Emprestimo DetalhesEmprestimo(int id);
        Emprestimo SimularEmprestimo(decimal ValorEmprestimo, int QuantidadeParcelas);
        Emprestimo NovoEmprestimo(decimal ValorEmprestimo, int QuantidadeParcelas, int id);
    }
}
