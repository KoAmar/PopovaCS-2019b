using System.Diagnostics;
using MainMVC.Models;
using MainMVC.Models.Polls;
using MainMVC.Models.Polls.Entities;
using MainMVC.Models.Users;
using MainMVC.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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

        public IActionResult PollsList()
        {
            var model = _pollRepository.GetPolls();
            return View(model);
        }

        public IActionResult PollStatistics(int id)
        {
            var model = _pollRepository.GetPoll(id);
            return View(model);
        }

        [HttpGet]
        public IActionResult CreatePoll() => View();

        [HttpPost]
        public IActionResult CreatePoll(Poll poll)
        {
            IActionResult result = View();
            if (ModelState.IsValid)
            {
                //TODO Login Of creator
                poll.CreatorLogin = "Controller";
                TempData.Put("poll", poll);
                result = RedirectToAction("EditPoll");
            }

            return result;
        }

        [HttpGet]
        public IActionResult EditPoll()
        {
            var poll = TempData.Get<Poll>("poll");
            IActionResult result = View(poll);

            if (poll == null) result = NotFound();
            return result;
        }

        [HttpPost]
        public IActionResult EditPoll(Poll poll)
        {
            Poll resultPoll;
            if (_pollRepository.GetPoll(poll.Id) != null)
                resultPoll = _pollRepository.Update(poll);
            else
                resultPoll = _pollRepository.Add(poll);
            return RedirectToAction("PollStatistics", "Home", new { id = resultPoll.Id });
            //return RedirectToAction("PollsList");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}