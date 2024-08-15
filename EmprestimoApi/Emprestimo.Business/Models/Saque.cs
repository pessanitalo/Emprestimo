using System.ComponentModel.DataAnnotations;


namespace CredEmprestimo.Business.Models
{
    public class Saque
    {
        [Key]
        public int SaqueId { get; set; }
        public int ClienteId { get; set; }
        public decimal ValorSaque { get; set; }
        public DateTime DataSaque { get; set; }
    }
}
