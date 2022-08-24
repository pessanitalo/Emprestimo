using EmprestimoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmprestimoApi.DataContext
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
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
