using Loja1.Context;
using Loja1.Models;
using Loja1.Repositories.Interfaces;

namespace Loja1.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;



    }
}
