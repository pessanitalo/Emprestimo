using CredEmprestimo.Business.Interface;
using CredEmprestimo.Business.Models;
using CredEmprestimo.Business.Models.Utils;
using CredEmprestimo.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CredEmprestimo.Data.Repository
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly DataContext _context;
        private readonly IClienteRepository _clienteRepository;


        public EmprestimoRepository(DataContext context, IClienteRepository clienteRepository)
        {
            _context = context;
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<Emprestimo>> ListarEmprestimos()
        {
            var list = await _context.Emprestimos.ToListAsync();
            return list;
        }

        public Emprestimo DetalhesEmprestimo(int id)
        {
            var emprestimo = _context.Emprestimos.Include(c => c.Cliente)
            .Where(x => x.Id == id).FirstOrDefault(X => X.Id == id);

            return emprestimo;
        }
        public Emprestimo SimularEmprestimo(decimal ValorEmprestimo, int QuantidadeParcelas)
        {
            var emprestimo = new Emprestimo(ValorEmprestimo, QuantidadeParcelas);
            emprestimo.SimularEmprestimo(ValorEmprestimo, QuantidadeParcelas);
            return emprestimo;
        }


        public Emprestimo NovoEmprestimo(decimal ValorEmprestimo, int QuantidadeParcelas, int id)
        {
            var emprestimo = new Emprestimo(ValorEmprestimo, QuantidadeParcelas);
            var cliente = _clienteRepository.DetalhesCliente(id);

            emprestimo.emprestimo(ValorEmprestimo, QuantidadeParcelas, cliente);

            _context.Emprestimos.Add(emprestimo);
            _context.SaveChanges();

            return emprestimo;
        }

        public async Task<PageList<Emprestimo>> ListaEmprestimo(PageParams pageParams)
        {
            IQueryable<Emprestimo> query = _context.Emprestimos;

            return await PageList<Emprestimo>.CreateAsync(query, pageParams.PageNumber, pageParams.pageSize);
        }
    }
}
