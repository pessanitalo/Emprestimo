using System.ComponentModel.DataAnnotations;

namespace EmprestimoApi.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public double Score { get; set; }
        public double SaldoAtual { get; set; }
        public Emprestimo? Emprestimo { get; set; }
    }
}
