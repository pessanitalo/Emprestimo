using CredEmprestimo.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace CredEmprestimo.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Emprestimo>()
                .HasOne(x => x.Cliente)
                .WithOne(x => x.Emprestimo);
        }
    }
}
