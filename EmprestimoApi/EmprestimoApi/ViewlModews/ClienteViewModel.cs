using System.ComponentModel.DataAnnotations;

namespace CredEmprestimoApi.ViewlModews
{
    public class ClienteViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 4)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(11, ErrorMessage = "O campo {0} precisa ter entre {2} caracteres", MinimumLength = 11)]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double Score { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double SaldoAtual { get; set; }
    }
}
