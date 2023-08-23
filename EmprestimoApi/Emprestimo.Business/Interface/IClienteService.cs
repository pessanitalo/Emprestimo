using CredEmprestimo.Business.Models;
using CredEmprestimo.Business.Models.Utils;

namespace CredEmprestimo.Business.Interface
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> filtroPorNome(string cliente);
        Task<PageList<Cliente>> ListaClientes(PageParams pageParams);
    }
}
