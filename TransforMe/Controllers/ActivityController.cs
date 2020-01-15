using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TransforMe.BLLFactory;
using TransforMe.Interface;
using TransforMe.Interface.Logics;
using TransforMe.ViewModels;

namespace TransforMe.Controllers
{
    public class ActivityController : Controller
    {
        private readonly IUserLogic _userLogic;

        public ActivityController()
        {
            _userLogic = LogicFactory.CreateUserLogic();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(ActivityViewModel viewModel)
        {
            var currentUser = _userLogic.GetUser(User.Identity.Name);

            if (!ModelState.IsValid)
            {
                return View();
            }

            IActivity newActivity = ModelFactory.CreateActivity();
            {
                newActivity.Description = viewModel.Description;
                newActivity.Date = viewModel.Date;
            }

            if (_userLogic.PlanActivity(newActivity, currentUser.Id))
            {
                return View();
            }

            return View();
        }
    }
}