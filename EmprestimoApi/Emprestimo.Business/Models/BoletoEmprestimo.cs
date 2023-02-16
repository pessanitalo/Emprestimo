namespace CredEmprestimo.Business.Models
{
    public class BoletoEmprestimo
    {
        public int Id { get; set; }
        public int NumeroParcela { get; set; }
        public double ValorDaParcela { get; set; }
        public DateTime DataDePagamento { get; set; }

        public int EmprestimoId { get; set; }
        public Emprestimo Emprestimo { get; set; }
    }
}
