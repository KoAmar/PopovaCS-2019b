using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_v2.Models;
using MVC_v2.Models.Pulls;

namespace MVC_v2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPullRepository _pullRepository;

        public HomeController(ILogger<HomeController> logger, IPullRepository pullRepository)
        {
            _pullRepository = pullRepository;
            _logger = logger;
        }

        public IActionResult Pulls()
        {
            var model = _pullRepository.GetPulls();
            return View(model);
        }

        public IActionResult Pull(int id)
        {
            var model = _pullRepository.GetPull(id);
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        public IActionResult Pavlik()
        {
            return View();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}