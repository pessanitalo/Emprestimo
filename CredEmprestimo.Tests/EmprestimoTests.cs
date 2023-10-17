using CredEmprestimo.Business.Models;
using FluentAssertions;

namespace CredEmprestimo.Tests
{
    public class EmprestimoTests
    {
        [Fact]
        public void EmprestimoValidarValorEmprestimo()
        {
            Action action = () => new Emprestimo(50,10);
            action.Should().Throw<Business.Validation.DomainExceptionValidation>()
                .WithMessage("O valor do emprestimo deve ser maior que cem reais");
        }

        [Fact]
        public void EmprestimoValidarQuantidadeParcelas()
        {
            Action action = () => new Emprestimo(200, 1);
            action.Should().Throw<Business.Validation.DomainExceptionValidation>()
                .WithMessage("A quantidade de parcelas deve ser maior que duas vezes.");
        }
    }
}