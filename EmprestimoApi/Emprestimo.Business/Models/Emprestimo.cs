namespace CredEmprestimo.Business.Models
{
    public class Emprestimo
    {
        public int Id { get; set; }

        public decimal ValorEmprestimo { get; set; }

        public int QuantidadeParcelas { get; set; }

        public decimal ValorDaParcela { get; set; }

        public decimal valorTotal { get; set; }

        public DateTime DataAquisicaoEmprestimo { get; set; }

        public IList<BoletoEmprestimo> BoletoEmprestimo { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public decimal valorTotalComJuros(decimal valorEmprestimo)
        {
            //testar
            decimal juros = 0.39m;
            return valorEmprestimo += valorEmprestimo * juros;
        }

        //testar
        public int ValorParcela(decimal valorTotal, int qtdParcelas)
        {
            return (int)(valorTotal / qtdParcelas);
        }
        public void emprestimo(decimal valorEmprestimo, int quantidadeParcelas, Cliente cliente)
        {
            ValorEmprestimo = valorEmprestimo;
            QuantidadeParcelas = quantidadeParcelas;
            valorTotal = valorTotalComJuros(valorEmprestimo);
            ValorDaParcela = ValorParcela(valorTotal, quantidadeParcelas);

            DataAquisicaoEmprestimo = DateTime.Now;

            Cliente = cliente;
            Cliente.SaldoAtual += valorEmprestimo;
        }

    }
}
