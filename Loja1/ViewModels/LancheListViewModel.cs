using Loja1.Models;

namespace Loja1.ViewModels
{
    public class LancheListViewModel
    {
        public IEnumerable <Lanche> Lanches { get; set; }
        public string CategoriaAtual { get; set; }  

    }
}
