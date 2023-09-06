using CredEmprestimo.Business.Models;
using CredEmprestimo.Business.Models.Utils;

namespace CredEmprestimo.Business.Interface
{
    public interface IClienteService
    {
        Task<PageList<Cliente>> Busca(PageParams pageParams, string cpf);
        Task<PageList<Cliente>> ListaClientes(PageParams pageParams);
        Cliente Create(Cliente cliente);        
        Cliente DetalhesCliente(int id);
        Task<bool> validar(Cliente cliente);
        decimal VerificarSaldo(int id);
    }
}
