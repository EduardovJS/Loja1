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
                lanches = _lancheRepository.Lanches.Where(l => l.Categoria.CategoriaNome.Equals(categoria)).OrderBy(c => c.Nome);
            }
            var lancheListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual,
            };
            return View(lancheListViewModel);
        }

        public IActionResult Details(int id)
        {
            var lanches = _lancheRepository.Lanches.FirstOrDefault(c => c.LancheId == id);
            return View(lanches);
        }

        public ViewResult Search(string searchstring)
        {
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(searchstring))
            {
                lanches = _lancheRepository.Lanches.OrderBy(x => x.LancheId);
                categoriaAtual = "Todos os Lanches";
            }
            else
            {
                lanches = _lancheRepository.Lanches.Where(x => x.Nome.ToLower().Contains(searchstring.ToLower()));

                if (lanches.Any())
                    categoriaAtual = "Lanches";
                else
                    categoriaAtual = "Nenhum lanche foi encontrado";
            }

            return View("~/Views/Lanches/List.cshtml", new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual,
            });
        }



    }
}
