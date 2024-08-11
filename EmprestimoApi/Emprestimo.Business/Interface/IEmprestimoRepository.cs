using CredEmprestimo.Business.Models;
using CredEmprestimo.Business.Models.Utils;

namespace CredEmprestimo.Business.Interface
{
    public interface IEmprestimoRepository
    {
        Task<IEnumerable<Emprestimo>> ListarEmprestimos();
        Task<PageList<Emprestimo>> ListaEmprestimo(PageParams pageParams);
        Task<PagedResult<Emprestimo>> ListarEmprestimos(int pageSize, int pageIndex);
        Emprestimo DetalhesEmprestimo(int id);
        Emprestimo SimularEmprestimo(decimal ValorEmprestimo, int QuantidadeParcelas);
        Emprestimo NovoEmprestimo(decimal ValorEmprestimo, int QuantidadeParcelas, int id);
    }
}
