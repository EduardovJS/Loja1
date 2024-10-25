using Loja1.Context;
using Loja1.Models;
using Loja1.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Loja1.Repositories
{
    public class LancheRepository : ILancheRepository
    {
        private readonly AppDbContext _context;
        public LancheRepository(AppDbContext context)
        {

            _context = context;
        }
        public IEnumerable<Lanche> Lanches => _context.Lanches.Include(c => c.Categoria);

        public IEnumerable<Lanche> LanchePreferido => _context.Lanches.Where(x => x.IsLanchePreferido).Include(x => x.Categoria);

        public Lanche GetLancheById(int lanchesid)
        {
            return _context.Lanches.FirstOrDefault(x=> x.LancheId == lanchesid);    
        }







    }
}
