using CredEmprestimo.Business.Validation;

namespace CredEmprestimo.Business.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Cpf { get; set; }
        public double Score { get; set; }
        public decimal SaldoAtual { get; set; }


        public Cliente(int id, string nome, int idade, string cpf, double score, decimal saldoAtual)
        {
            Id = id;
            Nome = nome;
            Idade = idade;
            Score = score;
            Cpf = cpf;
            SaldoAtual = saldoAtual;
            ValidateDomain(nome, idade, cpf, score, saldoAtual);
        }
        private void ValidateDomain(string nome, int idade, string cpf, double score, decimal saldoAtual)
        {
            DomainExceptionValidation.When(nome.Length < 3, "O Nome precisa ser maior que três caracteres.");
            DomainExceptionValidation.When(idade < 18, "A idade do cliente deve ser maior que dezoito anos.");
            DomainExceptionValidation.When(cpf.Length != 11, "O cpf do cliente precisa ter onze caracteres.");
            DomainExceptionValidation.When(score < 1, "O score do cliente precisa maior que um.");
            DomainExceptionValidation.When(saldoAtual < 1, "O cliente precisa ter um saldo inicial.");

            Nome = nome;
            Idade = idade;
            Cpf = Cpf;
            Score = score;
            SaldoAtual = saldoAtual;
        }

        public Emprestimo Emprestimo { get; set; }
    }
}
