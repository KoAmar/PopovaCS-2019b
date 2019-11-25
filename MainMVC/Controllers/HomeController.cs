using MainMVC.Models;
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
        private Question _presentlyEditingQuestion;
        private Poll _presentlyEditingPoll;

        public HomeController(ILogger<HomeController> logger, IPollRepository pollRepository, IUserRepository userRepository)
        {
            _pollRepository = pollRepository;
            _userRepository = userRepository;
            _logger = logger;
        }

        public IActionResult ListOfPolls()
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
                for (int num = 0; num < poll.QuestionsCount; num++)
                {
                    poll.Questions.Add(new Question());
                }
                var newPoll = _pollRepository.Add(poll);
                return RedirectToAction("EditNumberOfAnswers", new { id = newPoll.Id });
            }
            return View();
        }


        [HttpGet]
        public IActionResult EditNumberOfAnswers(int id, int question)
        {
            _presentlyEditingPoll = _pollRepository.GetPoll(id);
            var model = _presentlyEditingPoll.Questions[question];
            _presentlyEditingQuestion = model;
            return View(model);
        }

        [HttpPost]
        public IActionResult EditNumberOfAnswers(Question question)
        {
            if (ModelState.IsValid)
            {
                for (int num = 0; num < question.AnswersCount; num++)
                {
                    question.PossibleAnswers.Add(new Answer());
                }
                _presentlyEditingQuestion = question;
                return RedirectToAction("ListOfPolls");
            }
            //.Questions[question]; 
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