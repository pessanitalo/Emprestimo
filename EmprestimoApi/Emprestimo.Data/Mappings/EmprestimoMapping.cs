using CredEmprestimo.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CredEmprestimo.Data.Mappings
{
    public class EmprestimoMapping : IEntityTypeConfiguration<Emprestimo>
    {
        public void Configure(EntityTypeBuilder<Emprestimo> builder)
        {
            builder.ToTable("Emprestimo");

            builder.HasKey("Id");

            builder.Property(c => c.ValorEmprestimo)
            .IsRequired();

            builder.Property(c => c.QuantidadeParcelas)
            .IsRequired();

            builder.Property(c => c.ValorDaParcela)
            .IsRequired();

            builder.Property(c => c.valorTotal)
            .IsRequired();

            builder.Property(c => c.DataAquisicaoEmprestimo)
            .IsRequired()
            .HasColumnType("date");

            builder.HasOne(f => f.Cliente);

            builder.HasMany(f => f.BoletoEmprestimo)
           .WithOne(p => p.Emprestimo)
           .HasForeignKey(p => p.EmprestimoId);
        }
    }
}
