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
<<<<<<< HEAD

        public IEnumerable<Categoria> Categorias => _context.Categorias;



=======
        public IEnumerable<Categoria> Categorias => _context.Categorias;
>>>>>>> edc048a7a8b40c64f58f6101c18549fe0d8ef2dc
    }
}
