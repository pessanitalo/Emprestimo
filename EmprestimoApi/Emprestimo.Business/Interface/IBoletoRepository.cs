using CredEmprestimo.Business.Models;

namespace CredEmprestimo.Business.Interface
{
    public interface IBoletoRepository
    {
        BoletoEmprestimo GerarBoleto(int id);
        BoletoEmprestimo PagarUmaParcela(int id, int numeroDaParcela);
        List<BoletoEmprestimo> DetalhesParcela(int id);

    }
}
