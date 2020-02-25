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

        public IActionResult Index()
        {
            var model = _pollRepository.GetPolls();
            return View(model);
        }

        public IActionResult PollStatistics(int id)
        {
            var model = _pollRepository.GetPoll(id);
            HttpContext.Session.Put("passing_poll", model);
            return View(model);
        }

        [HttpGet]
        public IActionResult CreatePoll()
        {
            if (!_userRepository.IsLogged()) return NotFound();
            return View();
        }

        [HttpPost]
        public IActionResult CreatePoll(Poll poll)
        {
            IActionResult result = View();
            if (!_userRepository.IsLogged())
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                poll.CreatorLogin = _userRepository.GetCurrentUser().Login;
                poll.Questions = new List<Question>
                {
                    new Question
                    {
                        PossibleAnswers = new List<Answer>
                        {
                            new Answer(), new Answer(), new Answer()
                        }
                    },
                    new Question
                    {
                        PossibleAnswers = new List<Answer>
                        {
                            new Answer(), new Answer(), new Answer()
                        }
                    }
                };

                var newPoll = _pollRepository.Add(poll);
                HttpContext.Session.Put("poll", newPoll);
                result = RedirectToAction("EditPoll");
            }

            return result;
        }

        [HttpGet]
        public IActionResult EditPoll()
        {
            var poll = HttpContext.Session.Get<Poll>("poll");

            IActionResult result;
            if (poll != null)
            {
                result = View(poll);
            }
            else
            {
                result = NotFound(null);
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
            return RedirectToAction("PollStatistics", "Home", new { id = resultPoll.Id });
        }

        public IActionResult DeleteQuestion(int questionId)
        {
            var poll = HttpContext.Session.Get<Poll>("poll");
            poll.Questions = poll.Questions.Where(x => x.Id != questionId).ToList();
            var newPoll = _pollRepository.Update(poll);
            HttpContext.Session.Put("poll", newPoll);

            return RedirectToAction("EditPoll");
        }

        public IActionResult DeleteAnswer(int answerId)
        {
            var poll = HttpContext.Session.Get<Poll>("poll");

            foreach (var question in poll.Questions)
            {
                question.PossibleAnswers = question.PossibleAnswers.Where(answer => answer.Id != answerId).ToList();
            }

            var newPoll = _pollRepository.Update(poll);
            HttpContext.Session.Put("poll", newPoll);

            return RedirectToAction("EditPoll");
        }

        public IActionResult AddQuestion()
        {
            var poll = HttpContext.Session.Get<Poll>("poll");

            poll.Questions.Add(new Question());

            var newPoll = _pollRepository.Update(poll);
            HttpContext.Session.Put("poll", newPoll);

            return RedirectToAction("EditPoll");

        }

        public IActionResult AddAnswer(int questionId)
        {
            IActionResult result;
            var poll = HttpContext.Session.Get<Poll>("poll");

            if (poll == null)
            {
                result = NotFound();
            }
            else
            {
                foreach (var question in poll.Questions)
                {
                    if (questionId == question.Id)
                    {
                        question.PossibleAnswers.Add(new Answer());
                    }
                }

                var newPoll = _pollRepository.Update(poll);
                HttpContext.Session.Put("poll", newPoll);

                result = RedirectToAction("EditPoll");
            }

            return result;
        }

        [HttpGet]
        public IActionResult PassingOfThePoll()
        {

            var poll = HttpContext.Session.Get<Poll>("passing_poll");
            IActionResult result;
            if (poll != null)
            {
                var newPoll = poll.Clone();
                ModelState.Clear();
                result = View(newPoll);
            }
            else
            {
                result = NotFound();
            }

            return result;
        }

        [HttpPost]
        public IActionResult PassingOfThePoll(Poll poll)
        {
            ModelState.Clear();

            IActionResult result;
            if (poll != null)
            {

                if (ModelState.IsValid)
                {
                    HttpContext.Session.Remove("passing_poll");

                    for (var qi = 0; qi < poll.Questions.Count; qi++)
                    {
                        var question = poll.Questions[qi];
                        for (var ai = 0; ai < question.PossibleAnswers.Count; ai++)
                        {
                            var answer = question.PossibleAnswers[ai];
                            if (answer.AnswerSelected)
                            {
                                answer.AnswerSelected = false;
                                answer.AnswerSelectedCounter++;
                                _pollRepository.Update(poll);
                            }
                        }
                    }

                    result = RedirectToAction("PollStatistics", new { poll.Id });
                }
                else
                {
                    result = NotFound();
                }
            }
            else
            {
                result = NotFound();
            }

            return result;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}