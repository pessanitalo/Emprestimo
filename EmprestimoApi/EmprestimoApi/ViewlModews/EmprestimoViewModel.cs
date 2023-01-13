using System.ComponentModel.DataAnnotations;

namespace CredEmprestimoApi.ViewlModews
{
    public class EmprestimoViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double ValorEmprestimo { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int QuantidadeParcelas { get; set; }

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
