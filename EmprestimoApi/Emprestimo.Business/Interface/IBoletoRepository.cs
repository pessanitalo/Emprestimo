using CredEmprestimo.Business.Models;

namespace CredEmprestimo.Business.Interface
{
    public interface IBoletoRepository
    {
        BoletoEmprestimo GerarBoleto(int id);
        BoletoEmprestimo PagarUmaParcela(int id, int numeroDaParcela);
       Task <IEnumerable<BoletoEmprestimo>> VisualizarParcela(int id);

    }
}
