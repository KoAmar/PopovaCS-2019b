using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MainMVC.Models;
using MainMVC.Models.Polls;
using MainMVC.Models.Users;

namespace MainMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPollRepository _pollRepository;
        private readonly IUserRepository _userRepository;

        public HomeController(ILogger<HomeController> logger, IPollRepository pollRepository, IUserRepository userRepository)
        {
            _pollRepository = pollRepository;
            _userRepository = userRepository;
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
            if (ModelState.IsValid)
            {
                for (int num = 0; num < poll.QuestionsCount; num++)
                {
                    poll.Questions.Add(new Question());
                }
                var newPoll = _pollRepository.Add(poll);
                return RedirectToAction("Poll", new { id = newPoll.Id });
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}