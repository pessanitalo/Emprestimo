namespace CredEmprestimo.Business.Models
{
    public class PagarParcela
    {
        public int ClienteId { get; set; }
        public int EmprestimoId { get; set; }
        public int numeroParcela { get; set; }
    }
}
