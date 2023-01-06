using CredEmprestimo.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CredEmprestimo.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            //// 1 : 1 => Cliente : Emprestimo
            builder.HasKey("Id");

            builder.HasOne(f => f.Emprestimo) // endereço esta em fornecedor
                .WithOne(e => e.Cliente);

        }
    }
}
