using CredEmprestimo.Business.Interface;
using CredEmprestimo.Business.Models;
using CredEmprestimo.Data.Context;
using Microsoft.EntityFrameworkCore;


namespace CredEmprestimo.Data.Repository
{
    public class SaqueRepository : ISaqueRepository
    {
        private readonly DataContext _context;

        public SaqueRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Saque>> GetAllSaque()
        {
            return await _context.Saque.ToListAsync();
        }
    }
}
