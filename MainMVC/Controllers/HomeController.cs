using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MainMVC.Models;
using MainMVC.Models.Polls;
using MainMVC.Models.Polls.Entities;
using MainMVC.Models.Users;
using MainMVC.Utilities;
using MainMVC.Utilities.Controller;
using Microsoft.AspNetCore.Http;
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
                HttpContext.Session.Put("poll", poll);
                //TempData.Put("poll", poll);
                result = RedirectToAction("EditPoll");
            }

            return result;
        }

        [HttpGet]
        public IActionResult EditPoll()
        {
            IActionResult result = NotFound();
            var poll = HttpContext.Session.Get<Poll>("poll");

            //var tempData = (Poll)Data.GetData()[0].Clone();
            if (poll != null)
            {
                poll.Questions = new List<Question>()
                    {
                        new Question(){PossibleAnswers = new List<Answer>(){new Answer(),new Answer(),new Answer()}}
                    };

                result = View(poll);

            }
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
            HttpContext.Session.Remove("poll");
            //HttpContext.Session.Get<Poll>("")
            return RedirectToAction("PollStatistics", "Home", new { id = resultPoll.Id });
            //return RedirectToAction("PollsList");
        }

        public IActionResult DeleteQuestion(int questionId)
        {
            var poll = HttpContext.Session.Get<Poll>("poll");
            poll.Questions.Remove(poll.Questions.Single(q => q.Id == questionId));
            HttpContext.Session.Put("poll",poll);
            return RedirectToAction("EditPoll");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}