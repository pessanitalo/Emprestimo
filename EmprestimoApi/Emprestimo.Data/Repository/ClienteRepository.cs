using CredEmprestimo.Business.Interface;
using CredEmprestimo.Business.Models;
using CredEmprestimo.Business.Models.Utils;
using CredEmprestimo.Data.Context;
using CredEmprestimo.Data.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections;
using System.Data;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace CredEmprestimo.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DataContext _context;
        private readonly string _connectionString;

        public ClienteRepository(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<PageList<Cliente>> Busca(PageParams pageParams, string cpf)
        {
            var cliente = _context.Clientes.Where(c => c.Cpf.Contains(cpf));
            return await PageList<Cliente>.CreateAsync(cliente, pageParams.PageNumber, pageParams.pageSize);

        }
        public Cliente DetalhesCliente(int id)
        {
            var consulta = _context.Clientes.
               FirstOrDefault(X => X.ClienteId == id);

            return consulta;
        }
        public Cliente Create(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return cliente;
        }
        public async Task<IEnumerable> Validar(string cpf)
        {
            var clientes = await _context.Clientes.Where(c => c.Cpf == cpf).ToListAsync();
            return clientes;
        }

        public decimal VerificarSaldo(int id)
        {
            var cliente = _context.Emprestimos.FirstOrDefault(x => x.EmprestimoId == id);
            var saldo = _context.Clientes.FirstOrDefault(x => x.ClienteId == cliente.ClienteId);

            return saldo.SaldoAtual;
        }

        public async Task<PagedResult<Cliente>> ListaCliente(int pageSize, int pageIndex, string cpf)
        {
            var clientesQuery = _context.Clientes.AsQueryable();

            clientesQuery = clientesQuery
                    .WhereIf(!string.IsNullOrEmpty(cpf), p => p.Cpf == cpf);

            var catalog = await clientesQuery.AsNoTrackingWithIdentityResolution()
                                      .Skip(pageSize * (pageIndex - 1))
                                      .Take(pageSize).ToListAsync();

            return new PagedResult<Cliente>()
            {
                List = catalog,
                PageIndex = pageIndex,
                PageSize = pageSize,
            };
        }

        public async Task<ICollection<Cliente>> GetSpClientes()
        {
            var clientes = new List<Cliente>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("sp_ListaClientes", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var cliente = new Cliente
                            {
                                ClienteId = reader.GetInt32(reader.GetOrdinal("ClienteID")),
                                Nome = reader.GetString(reader.GetOrdinal("Nome")),
                                Idade = reader.GetInt32(reader.GetOrdinal("Idade")),
                                Cpf = reader.GetString(reader.GetOrdinal("Cpf")),
                                Score = reader.GetDouble(reader.GetOrdinal("Score")),
                                SaldoAtual = reader.GetDecimal(reader.GetOrdinal("SaldoAtual")),
                            };
                            clientes.Add(cliente);
                        }
                    }
                }
            }

            return clientes;
        }

        public async Task<PageList<Cliente>> Paginacao(PageParams pageParams, string cpf)
        {
            IQueryable<Cliente> cliente = _context.Clientes;
            return await PageList<Cliente>.CreateAsync(cliente, pageParams.PageNumber, pageParams.pageSize);

        }
    }
}
