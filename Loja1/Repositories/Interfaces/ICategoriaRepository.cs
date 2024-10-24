using Loja1.Models;

namespace Loja1.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> Categorias { get; }  

    }
}
