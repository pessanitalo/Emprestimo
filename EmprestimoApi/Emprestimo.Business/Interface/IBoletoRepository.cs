using CredEmprestimo.Business.Models;

namespace CredEmprestimo.Business.Interface
{
    public interface IBoletoRepository
    {
        BoletoEmprestimo GerarBoleto(int id);
        BoletoEmprestimo PagarUmaParcela(int id, int numeroDaParcela);
        //bool geralBoletoVencido(int id);
        List<BoletoEmprestimo> DetalhesParcela(int id);

    }
}
