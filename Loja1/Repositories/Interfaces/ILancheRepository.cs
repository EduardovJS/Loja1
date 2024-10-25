using Loja1.Models;

namespace Loja1.Repositories.Interfaces
{
    public interface ILancheRepository
    {
        IEnumerable<Lanche> Lanches { get; }
        IEnumerable<Lanche> LanchePreferido { get; }
        Lanche GetLancheById(int id);
    }
}
