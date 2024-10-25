using Loja1.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Loja1.Controllers
{
    public class LanchesController : Controller
    {
        private readonly ILancheRepository _lancheRepository;

        public LanchesController (ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;   
        }


        public IActionResult List()
        {
            var list = _lancheRepository.Lanches;
            return View(list);
        }
    }
}
