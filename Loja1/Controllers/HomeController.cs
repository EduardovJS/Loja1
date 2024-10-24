using Loja1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Loja1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();

        }
    }
}
