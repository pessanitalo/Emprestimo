﻿using CredEmprestimo.Business.Models;
using CredEmprestimo.Business.Models.Utils;

namespace CredEmprestimo.Business.Interface
{
    public interface IClienteService
    {
        Task<PagedResult<Cliente>> ListaCliente(int pageSize, int pageIndex, string cpf);
        Task<PageList<Cliente>> Paginacao(PageParams pageParams, string cpf);
        Cliente Create(Cliente cliente);
        Cliente DetalhesCliente(int id);
        Task<bool> validar(Cliente cliente);
        decimal VerificarSaldo(int id);
    }
}
