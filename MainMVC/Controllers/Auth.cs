using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MainMVC.Models.Polls;
using MainMVC.Models.Polls.Entities;
using MainMVC.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace MainMVC.Controllers
{
    public class Auth : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IUserRepository _userRepository;

        public Auth(ILogger<HomeController> logger, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _logger = logger;
        }
        public IActionResult MyPage()
        {
            return View(_userRepository.GetCurrentUser());
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            IActionResult result = View(user);
            if (ModelState.IsValid)
            {
                if (_userRepository.Register(user) == null)
                {
                    result = RedirectToAction("MyPage", "Auth");
                }
                else
                {
                    result = RedirectToAction("Index", "Home");
                }
            }
            return result;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            IActionResult result = View(user);

            if (ModelState.IsValid)
            {
                if (_userRepository.Login(user) == null)
                {
                    result = RedirectToAction("MyPage", "Auth");
                }
                else
                {
                    result = RedirectToAction("Index", "Home");
                }
            }
            return result;

        }

        [HttpGet]
        public IActionResult UsersRolesList()
        {
            IActionResult result = NotFound();
            if (_userRepository.GetCurrentUser().Role == Models.Users.User.Roles.Admin)
            {
                if (ModelState.IsValid)
                {

                    result = View(_userRepository.GetUsers().ToList());
                }
                else
                {
                    result = RedirectToAction("Index", "Home");
                }
            }
            return result;

        }

        [HttpPost]
        public IActionResult UsersRolesList(IEnumerable<User> users)
        {
            IActionResult result = NotFound();

            if (_userRepository.GetCurrentUser().Role != Models.Users.User.Roles.Admin) return result;
            if (ModelState.IsValid)
            {
                _userRepository.SetUsers(new List<User>(users));
                result = RedirectToAction("Index", "Home");
            }
            else
            {
                result = View(users.ToList());
            }

            return result;

        }

        public IActionResult LogOut()
        {
            _userRepository.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}