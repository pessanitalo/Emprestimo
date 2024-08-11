using CredEmprestimo.Business.Models;
using System.Collections;

namespace CredEmprestimo.Business.Interface
{
    public interface IClienteRepository
    {
        Cliente Create(Cliente cliente);
        Task<PagedResult<Cliente>> ListaCliente(int pageSize, int pageIndex, string cpf);
        Cliente DetalhesCliente(int id);
        Task<IEnumerable> Validar(string cpf);
        decimal VerificarSaldo(int id);
    }
}
