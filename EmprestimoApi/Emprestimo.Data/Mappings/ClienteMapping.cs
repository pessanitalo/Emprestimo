using CredEmprestimo.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CredEmprestimo.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {

            builder.HasKey("Id");

            builder.Property(c => c.Nome)
               .IsRequired()
               .HasColumnType("varchar(50)");

            builder.Property(c => c.Idade)
              .IsRequired()
              .HasColumnType("int");

            builder.Property(c => c.Cpf)
              .IsRequired()
              .HasColumnType("varchar(11)");

            builder.HasOne(f => f.Emprestimo)
           .WithOne(e => e.Cliente)
           .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Clientes");

        }
    }
}
