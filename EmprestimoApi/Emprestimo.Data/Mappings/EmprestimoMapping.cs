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

            builder.Property(c => c.ValorEmprestimo);

            builder.Property(c => c.QuantidadeParcelas);
                 
            builder.Property(c => c.ValorDaParcela);

            builder.Property(c => c.valorTotal);
        }
    }
}
