using Loja1.Context;
using Loja1.Models;
using Microsoft.EntityFrameworkCore;

namespace Loja1.Repositories.Interfaces
{
    public class LanchesRepository : ILanchesRepository
    {
        private readonly AppDbContext _context;

        public LanchesRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Lanche> Lanches => _context.Lanches.Include(c => c.Categoria); // obtendo todos os lanches
        public IEnumerable<Lanche> LanchePreferido => _context.Lanches.Where(p => p.IsLanchePreferido).Include(c => c.Categoria); // obtendo todos os lanches e suas categorias

        public Lanche GetLancheById(int lancheId)
        {
            return _context.Lanches.FirstOrDefault(l => l.LancheId == lancheId);
        }






    }
}
