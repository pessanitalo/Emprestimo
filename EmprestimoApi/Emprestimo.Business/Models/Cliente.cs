namespace CredEmprestimo.Business.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Cpf { get; set; }
        public double Score { get; set; }
        public double SaldoAtual { get; set; }
        public Emprestimo Emprestimo { get; set; }
    }
}
