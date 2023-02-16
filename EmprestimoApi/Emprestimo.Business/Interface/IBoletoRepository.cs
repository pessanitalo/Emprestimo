using CredEmprestimo.Business.Models;

namespace CredEmprestimo.Business.Interface
{
    public interface IBoletoRepository
    {
        BoletoEmprestimo GerarBoleto(int id);
    }
}
