using Loja1.Models;
using Loja1.Repositories.Interfaces;
using Loja1.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Loja1.Controllers
{
    public class LanchesController : Controller
    {
        private readonly ILancheRepository _lancheRepository;

        public LanchesController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }


        public IActionResult List(string categoria)
        {

            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(l => l.LancheId);
                categoriaAtual = "Todos os lanches";
            }
            else
            {
                if (string.Equals("Normal", categoria, StringComparison.OrdinalIgnoreCase))
                {
                    lanches = _lancheRepository.Lanches.Where(l => l.Categoria.CategoriaNome.Equals("Normal")).OrderBy(l => l.Nome);
                }
                else
                {
                    lanches = _lancheRepository.Lanches.Where(l => l.Categoria.CategoriaNome.Equals("Natural")).OrderBy(l => l.Nome);
                }
                categoriaAtual = categoria;

            }
            var lancheListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual,
            };
            return View(lancheListViewModel);
        }
    }
}
