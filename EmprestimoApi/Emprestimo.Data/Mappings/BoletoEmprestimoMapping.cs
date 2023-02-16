using CredEmprestimo.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CredEmprestimo.Data.Mappings
{
    public class BoletoEmprestimoMapping : IEntityTypeConfiguration<BoletoEmprestimo>
    {
        public void Configure(EntityTypeBuilder<BoletoEmprestimo> builder)
        {
            builder.ToTable("Boleto");

            builder.HasKey("Id");

            builder.Property(c => c.NumeroParcela)
           .IsRequired();

            builder.Property(c => c.ValorDaParcela)
            .IsRequired();

            builder.Property(c => c.DataDePagamento)
            .IsRequired()
            .HasColumnType("date");
        }
    }
}
