using Loja1.Models;
using Loja1.Repositories.Interfaces;
using Loja1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Loja1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILancheRepository _lancheRepository;

        public HomeController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;   
        }



        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                LanchesPreferidos = _lancheRepository.LanchePreferido
            };

            return View(homeViewModel);

        }
    }
}
