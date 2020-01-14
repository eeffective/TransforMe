using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransforMe.BLLFactory;
using TransforMe.Interface;
using TransforMe.Interface.Logics;
using TransforMe.ViewModels;

namespace TransforMe.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserLogic _userLogic = LogicFactory.CreateUserLogic();

        [HttpGet]
        public IActionResult Index(int userId)
        {
            var currentUser = _userLogic.GetUser(User.Identity.Name);
            string currentProfilepicture = "data:image/jpeg;base64," + Convert.ToBase64String(_userLogic.GetProfilePicture(currentUser.Id), 0, _userLogic.GetProfilePicture(currentUser.Id).Length);
            var followingsMessages = _userLogic.GetFollowingsMessages(currentUser.Id).ToList();

            ViewData["firstname"] = currentUser.Firstname;
            ViewData["lastname"] = currentUser.Lastname;
            ViewData["profilepic"] = currentProfilepicture;
            ViewData["followers"] = _userLogic.GetFollowersAmount(currentUser.Id);
            ViewData["followings"] = _userLogic.GetFollowingAmount(currentUser.Id);

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
                    Id = message.Id,
                    Image = "data:image/jpeg;base64," + Convert.ToBase64String(_userLogic.GetProfilePicture(message.UserId), 0, _userLogic.GetProfilePicture(message.UserId).Length),
                    Username = _userLogic.GetUser(message.UserId).Username,
                    Text = message.Text,
                    PostedAt = message.PostedAt,

                });
            }

            foreach (IProgression progression in _userLogic.GetFollowingsProgressions(currentUser.Id))
            {
                viewModel.Progressions.Add(new ProgressionViewModel
                {
                    ProgressPicture = "data:/image/jpeg;base64," + Convert.ToBase64String(progression.ProgressPicture, 0, progression.ProgressPicture.Length),
                    Bodyweight = progression.Bodyweight,
                    Date = progression.Date,
                    Username = _userLogic.GetUser(progression.UserId).Username,
                    Id = _userLogic.GetUser(progression.UserId).Id
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

            if (message.Text != null && text.Length < 300)
            {
                var currentUser = _userLogic.GetUser(User.Identity.Name);

                IMessage newMessage = ModelFactory.CreateMessage();
                {
                    newMessage.Text = text;
                }

                if (_userLogic.PostMessage(newMessage, currentUser.Id))
                {
                    TempData["success-feedback"] = "Message successfully added!";
                    return RedirectToAction("Index", "User");
                }
            }

            TempData["error-feedback"] = "Either your input is empty or too long!";
            return RedirectToAction("Index", "User");


        }

        [HttpGet]
        public IActionResult ProgressionIndex()
        {
            var currentUser = _userLogic.GetUser(User.Identity.Name);
            string currentProfilepicture = "data:image/jpeg;base64," + Convert.ToBase64String(_userLogic.GetProfilePicture(currentUser.Id), 0, _userLogic.GetProfilePicture(currentUser.Id).Length);

            ViewData["firstname"] = currentUser.Firstname;
            ViewData["lastname"] = currentUser.Lastname;
            ViewData["profilepic"] = currentProfilepicture;
            ViewData["followers"] = _userLogic.GetFollowersAmount(currentUser.Id);
            ViewData["followings"] = _userLogic.GetFollowingAmount(currentUser.Id);


            List<ProgressionViewModel> pvm = new List<ProgressionViewModel>();

            foreach (IProgression progression in _userLogic.GetProgressionsByUserId(currentUser.Id))
            {
                pvm.Add(new ProgressionViewModel
                {
                    ProgressPicture = "data:/image/jpeg;base64," + Convert.ToBase64String(progression.ProgressPicture, 0, progression.ProgressPicture.Length),
                    Bodyweight = progression.Bodyweight,
                    Date = progression.Date,
                    Username = _userLogic.GetUser(currentUser.Id).Username,
                    Id = _userLogic.GetUser(progression.UserId).Id
                });
            }

            return View(pvm);
        }

        [HttpPost]
        public IActionResult ProgressionIndex(IFormFile picture, decimal bodyweight, DateTime date)
        {
            var currentUser = _userLogic.GetUser(User.Identity.Name);

            ProgressionViewModel pvm = new ProgressionViewModel();
            {
                pvm.Bodyweight = bodyweight;
                pvm.Date = date;
            }

            if (picture != null && picture.Length > 0 && bodyweight > 0 && date != null && date < DateTime.Now && date.Year > 2000)
            {
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

                if (_userLogic.PostProgression(newProgression, currentUser.Id))
                {
                    TempData["success-feedback"] = "Progression successfully added!";
                    return RedirectToAction("ProgressionIndex", "User");
                }
                else
                {
                    TempData["error-feedback"] = "Failed to add progressions, something went wrong!";
                    return RedirectToAction("ProgressionIndex", "User");
                }
            }

            TempData["error-feedback"] = "Either one (if not more) of the required input fields is empty or the date is not valid!";
            return RedirectToAction("ProgressionIndex", "User");

        }

        [HttpGet]
        public IActionResult AddActivity()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddActivity(ActivityViewModel viewModel)
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
                return RedirectToAction("Index", "User");
            }

            return View();
        }

        [HttpGet]
        public IActionResult UserProfile(int userId)
        {
            var currentUser = _userLogic.GetUser(User.Identity.Name);
            string currentProfilepicture = "data:image/jpeg;base64," + Convert.ToBase64String(_userLogic.GetProfilePicture(currentUser.Id), 0, _userLogic.GetProfilePicture(currentUser.Id).Length);
            string profileProfilePicture = "data:image/jpeg;base64," + Convert.ToBase64String(_userLogic.GetProfilePicture(userId), 0, _userLogic.GetProfilePicture(userId).Length);
            ViewData["firstname"] = currentUser.Firstname;
            ViewData["lastname"] = currentUser.Lastname;
            ViewData["profilepic"] = currentProfilepicture;
            ViewData["followers"] = _userLogic.GetFollowersAmount(currentUser.Id);
            ViewData["followings"] = _userLogic.GetFollowingAmount(currentUser.Id);
            TempData["followstatus"] = "FOLLOW";

            ProfileViewModel viewModel = new ProfileViewModel();
            {
                viewModel.Id = _userLogic.GetUser(userId).Id;
                viewModel.Firstname = _userLogic.GetUser(userId).Firstname;
                viewModel.Lastname = _userLogic.GetUser(userId).Lastname;
                viewModel.Username = _userLogic.GetUser(userId).Username;
                viewModel.Followers = _userLogic.GetFollowersAmount(userId);
                viewModel.Following = _userLogic.GetFollowingAmount(userId);
                viewModel.ProfilePicture = profileProfilePicture;
                viewModel.Messages = new List<MessageViewModel>();
                viewModel.Progressions = new List<ProgressionViewModel>();
            }

            if (_userLogic.IsFollowing(viewModel.Id, currentUser.Id))
            {
                TempData["followstatus"] = "UNFOLLOW";
            }

            foreach (IMessage message in _userLogic.GetMessagesByUserId(userId))
            {
                viewModel.Messages.Add(new MessageViewModel
                {
                    Id = message.Id,
                    Image = "data:image/jpeg;base64," + Convert.ToBase64String(_userLogic.GetProfilePicture(userId), 0, _userLogic.GetProfilePicture(userId).Length),
                    Username = _userLogic.GetUser(userId).Username,
                    Text = message.Text,
                    PostedAt = message.PostedAt,

                });
            }

            foreach (IProgression progression in _userLogic.GetProgressionsByUserId(userId))
            {
                viewModel.Progressions.Add(new ProgressionViewModel
                {
                    ProgressPicture = "data:/image/jpeg;base64," + Convert.ToBase64String(progression.ProgressPicture, 0, progression.ProgressPicture.Length),
                    Bodyweight = progression.Bodyweight,
                    Date = progression.Date,
                    Username = _userLogic.GetUser(userId).Username,
                    Id = _userLogic.GetUser(userId).Id,
                });
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult UserProfile()
        {
            var currentUser = _userLogic.GetUser(User.Identity.Name);
            int followerId = currentUser.Id;
            int userId = (int)TempData["userId"];
            ViewData["followstatus"] = null;

            if (!_userLogic.IsFollowing(userId, followerId))
            {
                ViewData["followstatus"] = "FOLLOW";
                _userLogic.Follow(userId, currentUser.Id);
                TempData["success-feedback"] = $"{_userLogic.GetUser(userId).Firstname} {_userLogic.GetUser(userId).Lastname} followed successfully!";
                return RedirectToAction("Index", "User");

            }
            ViewData["followstatus"] = "UNFOLLOW";
            _userLogic.Unfollow(userId, followerId);
            TempData["success-feedback"] = $"{_userLogic.GetUser(userId).Firstname} {_userLogic.GetUser(userId).Lastname} unfollowed successfully!";
            return RedirectToAction("Index", "User");
        }

        public IActionResult SearchUser(string searchInput)
        {
            if (searchInput != null)
            {
                if (_userLogic.GetUser(searchInput.Trim()) != null)
                {
                    return RedirectToAction("UserProfile", "User", new { userId = _userLogic.GetUser(searchInput).Id });
                }
                else
                {
                    TempData["error-feedback"] = $"No user found with the username {searchInput.Trim()}";
                    return RedirectToAction("Index", "User");
                }
            }
            TempData["error-feedback"] = $"No username given, try again!";
            return RedirectToAction("Index", "User");

        }

        public IActionResult DeleteMessage(int messageId)
        {
            var currentUser = _userLogic.GetUser(User.Identity.Name);

            if (_userLogic.DeleteMessage(messageId))
            {
                TempData["success-feedback"] = $"Message has been deleted successfully!";
                return RedirectToAction("UserProfile", "User", new { userId = currentUser.Id });
            }

            return RedirectToAction("Index", "User");

        }
        public IActionResult DeleteProgression(int progressionId)
        {
            // TODO: Delete progression must be implemented still
            if (_userLogic.DeleteProgression(progressionId))
            {
                TempData["success-feedback"] = $"Progression has been deleted successfully!";
                return RedirectToAction("ProgressionIndex", "User");
            }

            return RedirectToAction("Index", "User");

        }

        public IActionResult UserSettings()
        {
            return View();
        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Home");
        }
    }
}