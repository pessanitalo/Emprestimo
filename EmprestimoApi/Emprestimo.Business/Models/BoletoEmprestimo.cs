using System.ComponentModel.DataAnnotations;

namespace CredEmprestimo.Business.Models
{
    public class BoletoEmprestimo
    {
        [Key]
        public int BoletoId { get; set; }
        public int NumeroParcela { get; set; }
        public decimal ValorDaParcela { get; set; }
        public DateTime DataDePagamento { get; set; }

        public int EmprestimoId { get; set; }
        public Emprestimo Emprestimo { get; set; }
    }
}
