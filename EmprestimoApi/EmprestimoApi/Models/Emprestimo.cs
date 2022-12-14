using System.ComponentModel.DataAnnotations;

namespace EmprestimoApi.Models
{
    public class Emprestimo
    {
        [Key]
        public int Id { get; set; }
        public int ClienteId { get; set; }
        
        public double ValorEmprestimo { get; set; }
        
        public int QuantidadeParcelas { get; set; }
        
        public double ValorDaParcela { get; set; }
       
        public double valorTotal { get; set; }
        
        public Cliente Cliente { get; set; }

        public double ValorTotal(double valorEmprestimo)
        {
            return valorEmprestimo += valorEmprestimo * 0.39;
        }

        public double ValorParcela(double valorTotal, double qtdParcelas)
        {
            return valorTotal / qtdParcelas;
        }
    }
}
