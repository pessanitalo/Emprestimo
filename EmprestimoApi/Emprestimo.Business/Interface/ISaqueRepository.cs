using CredEmprestimo.Business.Models;

namespace CredEmprestimo.Business.Interface
{
    public interface ISaqueRepository
    {
        Task<ICollection<Saque>> GetAllSaque();
    }
}
