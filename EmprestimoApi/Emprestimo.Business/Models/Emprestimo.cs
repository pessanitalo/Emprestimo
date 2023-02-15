namespace CredEmprestimo.Business.Models
{
    public class Emprestimo
    {
        //entidade dependente
        public int Id { get; set; }

        public double ValorEmprestimo { get; set; }

        public int QuantidadeParcelas { get; set; }

        public double ValorDaParcela { get; set; }

        public double valorTotal { get; set; }

        //Relacionamento
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }


        public double valorTotalComJuros(double valorEmprestimo)
        {
            return valorEmprestimo += valorEmprestimo * 0.39;
        }

        public double ValorParcela(double valorTotal, double qtdParcelas)
        {
            return valorTotal / qtdParcelas;
        }
    }
}
