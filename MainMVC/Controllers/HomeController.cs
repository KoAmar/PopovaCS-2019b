using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_v2.Models;
using MVC_v2.Models.Polls;

namespace MVC_v2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPollRepository _pollRepository;

        public HomeController(ILogger<HomeController> logger, IPollRepository pollRepository)
        {
            _pollRepository = pollRepository;
            _logger = logger;
        }

        public IActionResult Polls()
        {
            var model = _pollRepository.GetPolls();
            return View(model);
        }

        public IActionResult Poll(int id)
        {
            var model = _pollRepository.GetPoll(id);
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Poll poll)
        {
            var newPoll = _pollRepository.Add(poll);
            return RedirectToAction("Poll", new {id = newPoll.Id});
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}