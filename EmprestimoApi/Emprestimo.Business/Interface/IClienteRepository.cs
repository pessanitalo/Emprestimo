using CredEmprestimo.Business.Models;
using System.Collections;

namespace CredEmprestimo.Business.Interface
{
    public interface IClienteRepository
    {
        Cliente Create(Cliente cliente);
        Task<IEnumerable> ListaClientes();
        Task<Cliente> BuscaCpf(string cpf);
        Cliente DetalhesCliente(int id);
        Cliente PesquisarCliente(int id);
    }
}
