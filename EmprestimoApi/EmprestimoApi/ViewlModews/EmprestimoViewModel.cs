namespace CredEmprestimoApi.ViewlModews
{
    public class EmprestimoViewModel
    {
        public int ClienteId { get; set; }
        public double ValorEmprestimo { get; set; }

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
