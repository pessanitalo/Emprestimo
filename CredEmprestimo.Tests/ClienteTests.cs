using CredEmprestimo.Business.Models;
using FluentAssertions;

namespace CredEmprestimo.Tests
{
    public class ClienteTests
    {

        [Fact]
        public void ClienteValidarNome()
        {
            Action action = () => new Cliente(1, "It", 36, "09375500004", 10, 99.0m);
            action.Should().Throw<Business.Validation.DomainExceptionValidation>()
                .WithMessage("O Nome precisa ser maior que três caracteres.");
        }

        [Fact]
        public void ClienteValidarIdade()
        {
            Action action = () => new Cliente(1, "Italo", 17, "09375500004", 10, 99.0m);
            action.Should().Throw<Business.Validation.DomainExceptionValidation>()
                .WithMessage("A idade do cliente deve ser maior que dezoito anos.");
        }

        [Fact]
        public void ClienteValidarTamanhoDoCpf()
        {
            Action action = () => new Cliente(1, "Italo", 21, "093755004", 10, 99.0m);
            action.Should().Throw<Business.Validation.DomainExceptionValidation>()
                .WithMessage("O cpf do cliente precisa ter onze caracteres.");
        }

        [Fact]
        public void ClienteValidarScolre()
        {
            Action action = () => new Cliente(1, "Italo", 21, "42662382074", 0, 1000);
            action.Should().Throw<Business.Validation.DomainExceptionValidation>()
                .WithMessage("O score do cliente precisa maior que um.");
        }

        [Fact]
        public void ClienteValidarSaldoAtual()
        {
            Action action = () => new Cliente(1, "Italo", 21, "42662382074", 10, 0);
            action.Should().Throw<Business.Validation.DomainExceptionValidation>()
                .WithMessage("O cliente precisa ter um saldo inicial.");
        }
    }
}