using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CredEmprestimo.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Score = table.Column<double>(type: "float", nullable: false),
                    SaldoAtual = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Emprestimo",
                columns: table => new
                {
                    EmprestimoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorEmprestimo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantidadeParcelas = table.Column<int>(type: "int", nullable: false),
                    ValorDaParcela = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    valorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataAquisicaoEmprestimo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprestimo", x => x.EmprestimoId);
                    table.ForeignKey(
                        name: "FK_Emprestimo_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Saque",
                columns: table => new
                {
                    SaqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    ValorSaque = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataSaque = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saque", x => x.SaqueId);
                    table.ForeignKey(
                        name: "FK_Saque_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoletoEmprestimo",
                columns: table => new
                {
                    BoletoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroParcela = table.Column<int>(type: "int", nullable: false),
                    ValorDaParcela = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataDePagamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmprestimoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoletoEmprestimo", x => x.BoletoId);
                    table.ForeignKey(
                        name: "FK_BoletoEmprestimo_Emprestimo_EmprestimoId",
                        column: x => x.EmprestimoId,
                        principalTable: "Emprestimo",
                        principalColumn: "EmprestimoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoletoEmprestimo_EmprestimoId",
                table: "BoletoEmprestimo",
                column: "EmprestimoId");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_ClienteId",
                table: "Emprestimo",
                column: "ClienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Saque_ClienteId",
                table: "Saque",
                column: "ClienteId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoletoEmprestimo");

            migrationBuilder.DropTable(
                name: "Saque");

            migrationBuilder.DropTable(
                name: "Emprestimo");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
