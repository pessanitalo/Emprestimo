namespace CredEmprestimo.Business.Models
{
    public class Emprestimo
    {

        public int Id { get; set; }

        public double ValorEmprestimo { get; set; }

        public int QuantidadeParcelas { get; set; }

        public double ValorDaParcela { get; set; }

        public double valorTotal { get; set; }

        public DateTime DataAquisicaoEmprestimo { get; set; }

        public IList<BoletoEmprestimo> BoletoEmprestimo { get; set; }

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

        //public Emprestimo gerarEmprestimo(double ValorEmprestimo, int QuantidadeParcelas, Emprestimo emprestimo, Cliente cliente)
        //{
        //    emprestimo.ValorEmprestimo = ValorEmprestimo;
        //    emprestimo.QuantidadeParcelas = QuantidadeParcelas;

        //    var valorTotalComJuros = emprestimo.valorTotalComJuros(ValorEmprestimo);
        //    emprestimo.valorTotal = valorTotalComJuros;
        //    emprestimo.DataAquisicaoEmprestimo = DateTime.Now;

        //    var valorDaParcela = emprestimo.ValorParcela(valorTotalComJuros, QuantidadeParcelas);
        //    emprestimo.ValorDaParcela = valorDaParcela;
        //    emprestimo.Cliente = cliente;
        //    emprestimo.Cliente.SaldoAtual += emprestimo.ValorEmprestimo;

        //    return emprestimo;
        //}

        public void emprestimo(double valorEmprestimo, int quantidadeParcelas, Cliente cliente)
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
