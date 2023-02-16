using CredEmprestimo.Business.Models;

namespace CredEmprestimo.Business.Interface
{
    public interface IEmprestimoRepository
    {
        Task<IEnumerable<Emprestimo>> ListarEmprestimos();
        Emprestimo ObterPorId(int id);
        Emprestimo NovoEmprestimo(double ValorEmprestimo, int QuantidadeParcelas, int id);
    }
}
