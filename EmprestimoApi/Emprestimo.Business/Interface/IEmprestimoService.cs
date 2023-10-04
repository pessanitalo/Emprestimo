using CredEmprestimo.Business.Models;
using CredEmprestimo.Business.Models.Utils;

namespace CredEmprestimo.Business.Interface
{
    public interface IEmprestimoService
    {
        Task<IEnumerable<Emprestimo>> ListarEmprestimos();
        Task<PageList<Emprestimo>> ListaEmprestimo(PageParams pageParams);
        Emprestimo DetalhesEmprestimo(int id);
        Emprestimo SimularEmprestimo(decimal ValorEmprestimo, int QuantidadeParcelas);
        Emprestimo NovoEmprestimo(decimal ValorEmprestimo, int QuantidadeParcelas, int id);
    }
}
