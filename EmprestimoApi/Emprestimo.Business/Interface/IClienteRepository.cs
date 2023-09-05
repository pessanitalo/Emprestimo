using CredEmprestimo.Business.Models;
using CredEmprestimo.Business.Models.Utils;
using System.Collections;

namespace CredEmprestimo.Business.Interface
{
    public interface IClienteRepository
    {
        Cliente Create(Cliente cliente);
        Task<PageList<Cliente>> ListaClientes(PageParams pageParams);
        Task<PageList<Cliente>> Busca(PageParams pageParams, string cpf);
        Cliente DetalhesCliente(int id);
        Task <IEnumerable> Validar(string cpf);
    }
}
