using CredEmprestimo.Business.Models;
using CredEmprestimo.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace CredEmprestimo.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
        public DbSet<BoletoEmprestimo> BoletoEmprestimo { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ClienteMapping());
            builder.ApplyConfiguration(new EmprestimoMapping());
            builder.ApplyConfiguration(new BoletoEmprestimoMapping());
        }
    }
}
