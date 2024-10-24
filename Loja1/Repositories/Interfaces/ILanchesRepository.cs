using Loja1.Context;
using Loja1.Models;

namespace Loja1.Repositories.Interfaces
{
    public interface ILanchesRepository 
    {
        IEnumerable<Lanche> Lanches { get; }                
        IEnumerable<Lanche> LanchePreferido { get; }
        Lanche GetLancheById(int lancheId);

    }
}
