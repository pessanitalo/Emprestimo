﻿using CredEmprestimo.Business.Interface;
using CredEmprestimo.Business.Models;
using CredEmprestimo.Business.Models.Utils;

namespace CredEmprestimo.Business.Services
{
    public class ClienteServices : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteServices(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<PageList<Cliente>> ListaClientes(PageParams pageParams)
        {
            var clientes = await _clienteRepository.ListaClientes(pageParams);

            return clientes;

        }
        public async Task<PageList<Cliente>> Busca(PageParams pageParams, string cpf)
        {
            var busca = await _clienteRepository.Busca(pageParams, cpf);
            return busca;
        }

        public Cliente Create(Cliente cliente)
        {
            var novocliente = _clienteRepository.Create(cliente);

            return novocliente;
        }

        public async Task<bool> validar(Cliente cliente)
        {
            try
            {
                IList<Cliente> retorno = (IList<Cliente>)await _clienteRepository.Validar(cliente.Cpf);
                if (retorno.Count > 0) return true;
                return false;

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao verificar se usuário existe. Erro: {ex.Message}");
            }

        }

        public Cliente DetalhesCliente(int id)
        {
            var detalhe = _clienteRepository.DetalhesCliente(id);

            return detalhe;
        }

        public decimal VerificarSaldo(int id)
        {
            var cliente =  _clienteRepository.VerificarSaldo(id);
            return cliente;
        }
    }
}
