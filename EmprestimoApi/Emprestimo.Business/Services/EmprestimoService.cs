using CredEmprestimo.Business.Interface;
using CredEmprestimo.Business.Models;

namespace CredEmprestimo.Business.Services
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly IEmprestimoRepository _emprestimoRepository;

        public EmprestimoService(IEmprestimoRepository emprestimoRepository)
        {
            _emprestimoRepository = emprestimoRepository;
        }

        public Emprestimo DetalhesEmprestimo(int id)
        {
            var detalhes = _emprestimoRepository.DetalhesEmprestimo(id);
            return detalhes;
        }

        public Task<IEnumerable<Emprestimo>> ListarEmprestimos()
        {
            var lista = _emprestimoRepository.ListarEmprestimos();
            return lista;
        }

        public Emprestimo NovoEmprestimo(decimal ValorEmprestimo, int QuantidadeParcelas, int id)
        {
            var novoEmprestimo = _emprestimoRepository.NovoEmprestimo(ValorEmprestimo,QuantidadeParcelas,id);
            return novoEmprestimo;
        }
        public Emprestimo SimularEmprestimo(decimal ValorEmprestimo, int QuantidadeParcelas)
        {
            var simular = _emprestimoRepository.SimularEmprestimo(ValorEmprestimo,QuantidadeParcelas);
            return simular;
        }
    }
}
