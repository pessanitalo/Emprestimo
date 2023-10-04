using CredEmprestimo.Business.Models;
using CredEmprestimo.Business.Models.Utils;

namespace CredEmprestimo.Business.Interface
{
    public interface IBoletoService
    {
        BoletoEmprestimo GerarBoleto(int id);
        BoletoEmprestimo PagarUmaParcela(int id, int numeroDaParcela);
        Task<IEnumerable<BoletoEmprestimo>> VisualizarParcela(int id);
        Task<PageList<BoletoEmprestimo>> ListaBoletos(int id,PageParams pageParams);
        bool ValidarSaldo(int id);
    }
}
