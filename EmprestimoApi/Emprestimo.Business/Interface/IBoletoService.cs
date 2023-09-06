using CredEmprestimo.Business.Models;


namespace CredEmprestimo.Business.Interface
{
    public interface IBoletoService
    {
        BoletoEmprestimo GerarBoleto(int id);
        BoletoEmprestimo PagarUmaParcela(int id, int numeroDaParcela);
        List<BoletoEmprestimo> VisualizarParcela(int id);
        bool ValidarSaldo(int id);
    }
}
