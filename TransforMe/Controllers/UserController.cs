using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransforMe.BLLFactory;
using TransforMe.Interface;
using TransforMe.Interface.Logics;
using TransforMe.ViewModels;

namespace TransforMe.Controllers
{
    //[Authorize(Roles = "1")]
    public class UserController : Controller
    {
        private readonly IUserLogic userLogic = LogicFactory.CreateUserLogic();

        [HttpGet]
        public IActionResult Index(int userId)
        {
            var currentUser = userLogic.GetUser(User.Identity.Name);
            string currentProfilepicture = "data:image/jpeg;base64," + Convert.ToBase64String(userLogic.GetProfilePicture(currentUser.Id), 0, userLogic.GetProfilePicture(currentUser.Id).Length);
            var followingsMessages = userLogic.GetFollowingsMessages(currentUser.Id).ToList();

            ViewData["firstname"] = currentUser.Firstname;
            ViewData["lastname"] = currentUser.Lastname;
            ViewData["profilepic"] = currentProfilepicture;
            ViewData["followers"] = userLogic.GetFollowersAmount(currentUser.Id);
            ViewData["followings"] = userLogic.GetFollowingAmount(currentUser.Id);

            UserIndexViewModel viewModel = new UserIndexViewModel()
            {
                Messages = new List<MessageViewModel>(),
                Progressions = new List<ProgressionViewModel>()
            };

            followingsMessages.Find(message => message.UserId == userId);

            foreach (IMessage message in followingsMessages)
            {
                viewModel.Messages.Add(new MessageViewModel
                {
                    Image = "data:image/jpeg;base64," + Convert.ToBase64String(userLogic.GetProfilePicture(message.UserId), 0, userLogic.GetProfilePicture(message.UserId).Length),
                    Username = userLogic.GetUser(message.UserId).Username,
                    Text = message.Text,
                    PostedAt = message.PostedAt,

                });
            }

            foreach (IProgression progression in userLogic.GetFollowingsProgressions(currentUser.Id))
            {
                viewModel.Progressions.Add(new ProgressionViewModel
                {
                    ProgressPicture = "data:/image/jpeg;base64," + Convert.ToBase64String(progression.ProgressPicture, 0, progression.ProgressPicture.Length),
                    Bodyweight = progression.Bodyweight,
                    Date = progression.Date,
                    Username = userLogic.GetUser(progression.UserId).Username
                });
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(string text)
        {
            MessageViewModel message = new MessageViewModel();
            {
                message.Text = text;
            }

            if (message.Text == null)
            {
                TempData["error-mbox"] = "Text input can't be empty!";
                return RedirectToAction("Index", "User");
            }

            var currentUser = userLogic.GetUser(User.Identity.Name);

            IMessage newMessage = ModelFactory.CreateMessage();
            {
                newMessage.Text = text;
            }

            if (userLogic.PostMessage(newMessage, currentUser.Id))
            {
                TempData["success-feedback"] = "Message succesfully added!";
                return RedirectToAction("Index", "User");
            }

            return View(new UserIndexViewModel());
        }

        [HttpGet]
        public IActionResult ProgressionIndex()
        {
            var currentUser = userLogic.GetUser(User.Identity.Name);
            string currentProfilepicture = "data:image/jpeg;base64," + Convert.ToBase64String(userLogic.GetProfilePicture(currentUser.Id), 0, userLogic.GetProfilePicture(currentUser.Id).Length);

            ViewData["firstname"] = currentUser.Firstname;
            ViewData["lastname"] = currentUser.Lastname;
            ViewData["profilepic"] = currentProfilepicture;
            ViewData["followers"] = userLogic.GetFollowersAmount(currentUser.Id);
            ViewData["followings"] = userLogic.GetFollowingAmount(currentUser.Id);


            List<ProgressionViewModel> pvm = new List<ProgressionViewModel>();

            foreach (IProgression progression in userLogic.GetProgressionsByUserId(currentUser.Id))
            {
                pvm.Add(new ProgressionViewModel
                {
                    ProgressPicture = "data:/image/jpeg;base64," + Convert.ToBase64String(progression.ProgressPicture, 0, progression.ProgressPicture.Length),
                    Bodyweight = progression.Bodyweight,
                    Date = progression.Date,
                    Username = userLogic.GetUser(currentUser.Id).Username
                });
            }

            return View(pvm);
        }

        [HttpPost]
        public IActionResult ProgressionIndex(IFormFile picture, decimal bodyweight, DateTime date)
        {
            var currentUser = userLogic.GetUser(User.Identity.Name);

            ProgressionViewModel pvm = new ProgressionViewModel();
            {
                pvm.Bodyweight = bodyweight;
                pvm.Date = date;
            }

            if (picture == null || bodyweight < 0 || date == null)
            {
                TempData["error-feedback"] = "One (if not more) of the required input fields is empty!";
                return RedirectToAction("ProgressionIndex", "User");
            }

            IProgression newProgression = ModelFactory.CreateProgression();
            {
                {
                    using (var rs = picture.OpenReadStream())
                    using (var ms = new MemoryStream())
                    {
                        rs.CopyTo(ms);
                        newProgression.ProgressPicture = ms.ToArray();
                    }
                    newProgression.Bodyweight = bodyweight;
                    newProgression.Date = date;
                }
            }

            if (userLogic.PostProgression(newProgression, currentUser.Id))
            {
                TempData["success-feedback"] = "Progressions succesfully added!";
                return RedirectToAction("ProgressionIndex", "User");
            }
            else
            {
                TempData["error-feedback"] = "Failed to add progressions, something went wrong!";
                return RedirectToAction("ProgressionIndex", "User");
            }
        }

        [HttpGet]
        public IActionResult AddActivity()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddActivity(ActivityViewModel viewModel)
        {
            var currentUser = userLogic.GetUser(User.Identity.Name);

            if (!ModelState.IsValid)
            {
                return View();
            }
            IActivity newActivity = ModelFactory.CreateActivity();
            {
                newActivity.Description = viewModel.Description;
                newActivity.Date = viewModel.Date;
            }

            if (userLogic.PlanActivity(newActivity, currentUser.Id))
            {
                return RedirectToAction("Index", "User");
            }

            return View();
        }

        [HttpGet]
        public IActionResult UserProfile(int userId)
        {
            var currentUser = userLogic.GetUser(User.Identity.Name);
            string currentProfilepicture = "data:image/jpeg;base64," + Convert.ToBase64String(userLogic.GetProfilePicture(currentUser.Id), 0, userLogic.GetProfilePicture(currentUser.Id).Length);
            string profileProfilePicture = "data:image/jpeg;base64," + Convert.ToBase64String(userLogic.GetProfilePicture(userId), 0, userLogic.GetProfilePicture(userId).Length);
            ViewData["firstname"] = currentUser.Firstname;
            ViewData["lastname"] = currentUser.Lastname;
            ViewData["profilepic"] = currentProfilepicture;
            ViewData["followers"] = userLogic.GetFollowersAmount(currentUser.Id);
            ViewData["followings"] = userLogic.GetFollowingAmount(currentUser.Id);

            ViewData["profilefirstname"] = userLogic.GetUser(userId).Firstname;
            ViewData["profilelastname"] = userLogic.GetUser(userId).Lastname;
            ViewData["profilefollowers"] = userLogic.GetFollowersAmount(userId);
            ViewData["profilefollowing"] = userLogic.GetFollowingAmount(userId);
            ViewData["profileProfilepic"] = profileProfilePicture;

            ProfileViewModel viewModel = new ProfileViewModel();
            {
                viewModel.Messages = new List<MessageViewModel>();
                viewModel.Progressions = new List<ProgressionViewModel>();
            }

            foreach (IMessage message in userLogic.GetMessagesByUserId(userId))
            {
                viewModel.Messages.Add(new MessageViewModel
                {
                    Image = "data:image/jpeg;base64," + Convert.ToBase64String(userLogic.GetProfilePicture(userId), 0, userLogic.GetProfilePicture(userId).Length),
                    Username = userLogic.GetUser(userId).Username,
                    Text = message.Text,
                    PostedAt = message.PostedAt,

                });
            }

            foreach (IProgression progression in userLogic.GetProgressionsByUserId(userId))
            {
                viewModel.Progressions.Add(new ProgressionViewModel
                {
                    ProgressPicture = "data:/image/jpeg;base64," + Convert.ToBase64String(progression.ProgressPicture, 0, progression.ProgressPicture.Length),
                    Bodyweight = progression.Bodyweight,
                    Date = progression.Date,
                    Username = userLogic.GetUser(userId).Username
                });
            }

            return View(viewModel);
        }

    }
}