using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TransforMe.BLLFactory;
using TransforMe.Interface;
using TransforMe.Interface.Logics;
using TransforMe.Models;
using TransforMe.ViewModels;

namespace TransforMe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserLogic userLogic = LogicFactory.CreateUserLogic();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Password", "Invalid login attempt, try again!");
                return View();
            }

            if (userLogic.ValidateLogin(viewModel.Username, viewModel.Password))
            {
                var role = userLogic.GetRole(viewModel.Username);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, viewModel.Username),
                    new Claim(ClaimTypes.Role, role.ToString())
                };

                var userIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);

                switch (role)
                {
                    case 1:
                        return RedirectToAction("Index", "User");
                    case 2:
                        return RedirectToAction("Index", "Admin");
                }
            }
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Register()
        {
            RegisterViewModel viewModel = new RegisterViewModel();
            {
                viewModel.SecurityQuestions = new List<string>();
            }

            foreach (var question in userLogic.GetAllQuestions())
            {
                viewModel.SecurityQuestions.Add(question);
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel viewModel)
        {
            if (viewModel.Firstname == viewModel.Lastname)
            {
                ModelState.AddModelError("Last name", "Last name can't be the same as First name");
            }

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }


            IUser newUser = ModelFactory.CreateUser();
            {
                newUser.Firstname = viewModel.Firstname;
                newUser.Lastname = viewModel.Lastname;
                newUser.Username = viewModel.Username;
                newUser.Password = viewModel.Password;
                newUser.SecurityQuestion = viewModel.SecurityQuestions.Count;
                newUser.SecurityAnswer = viewModel.SecurityAnswer;
            }

            if (userLogic.Register(newUser))
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
