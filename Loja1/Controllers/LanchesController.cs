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


        public IActionResult List()
        {
            var lanchesListViewModel = new LancheListViewModel();
            lanchesListViewModel.Lanches = _lancheRepository.Lanches;
            lanchesListViewModel.CategoriaAtual = "Categoria Atual";
            return View(lanchesListViewModel);
        }
    }
}
