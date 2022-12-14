// <auto-generated />
using EmprestimoApi.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmprestimoApi.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220830001751_novo_campo_Cpf")]
    partial class novo_campo_Cpf
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EmprestimoApi.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Cpf")
                        .HasColumnType("int");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("SaldoAtual")
                        .HasColumnType("float");

                    b.Property<double>("Score")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("EmprestimoApi.Models.Emprestimo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadeParcelas")
                        .HasColumnType("int");

                    b.Property<double>("ValorDaParcela")
                        .HasColumnType("float");

                    b.Property<double>("ValorEmprestimo")
                        .HasColumnType("float");

                    b.Property<double>("valorTotal")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId")
                        .IsUnique();

                    b.ToTable("Emprestimos");
                });

            modelBuilder.Entity("EmprestimoApi.Models.Emprestimo", b =>
                {
                    b.HasOne("EmprestimoApi.Models.Cliente", "Cliente")
                        .WithOne("Emprestimo")
                        .HasForeignKey("EmprestimoApi.Models.Emprestimo", "ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("EmprestimoApi.Models.Cliente", b =>
                {
                    b.Navigation("Emprestimo");
                });
#pragma warning restore 612, 618
        }
    }
}
