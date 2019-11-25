﻿using MainMVC.Models;
using MainMVC.Models.Polls;
using MainMVC.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MainMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPollRepository _pollRepository;
        private readonly IUserRepository _userRepository;
        private int _presentlyEditingPollId;
        private int _presentlyEditingQuestionId;

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

        public IActionResult ViewPoll(int id)
        {
            var model = _pollRepository.GetPoll(id);
            return View(model);
        }

        [HttpGet]
        public IActionResult CreatePoll()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePoll(Poll poll)
        {
            if (ModelState.IsValid)
            {
                for (int num = 1; num < poll.QuestionsCount + 1; num++)
                {
                    poll.Questions.Add(new Question() { Id = num });
                }
                var newPoll = _pollRepository.Add(poll);
                return RedirectToAction("QuestionsList", new { pollId = newPoll.Id });
            }
            return View();
        }

        public IActionResult QuestionsList(int pollId)
        {
            var poll = _pollRepository.GetPoll(pollId);
            _presentlyEditingPollId = poll.Id;
            var model = poll.Questions;
            return View(model);
        }

        [HttpGet]
        public IActionResult EditNumberOfAnswers(int questionId)
        {
            Question model = _pollRepository.GetQuestion(questionId);
            _presentlyEditingQuestionId = model.Id;
            return View(model);
        }

        [HttpPost]
        public IActionResult EditNumberOfAnswers(Question question)
        {
            if (ModelState.IsValid)
            {
                _pollRepository.UpdateQuestion(question);

                return RedirectToAction("QuestionsList", new { _presentlyEditingPollId });
            }
            return View(question);
        }

        public IActionResult EditAnswers(int id, int question)
        {
            var model = _pollRepository.GetPoll(id).Questions[question];
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}