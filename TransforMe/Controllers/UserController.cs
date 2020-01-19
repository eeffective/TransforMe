using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using TransforMe.BLLFactory;
using TransforMe.BusinessLogic.Models;
using TransforMe.Interface;
using TransforMe.Interface.Logics;
using TransforMe.ViewModels;

namespace TransforMe.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserLogic _userLogic;

        public UserController()
        {
            _userLogic = LogicFactory.CreateUserLogic();
        }

        [HttpGet]
        public IActionResult Index(int userId)
        {
            var currentUser = _userLogic.GetUser(User.Identity.Name);

            var allMessages = _userLogic.GetFollowingsMessages(currentUser.Id).ToList();
            allMessages.AddRange(_userLogic.GetMessagesByUserId(currentUser.Id));

            var allProgressions = _userLogic.GetFollowingsProgressions(currentUser.Id).ToList();
            allProgressions.AddRange(_userLogic.GetProgressionsByUserId(currentUser.Id));


            UserIndexViewModel viewModel = new UserIndexViewModel()
            {
                Messages = new List<MessageViewModel>(),
                Progressions = new List<ProgressionViewModel>()
            };


            foreach (IMessage message in allMessages.OrderByDescending(m => m.PostedAt).ToList())
            {
                viewModel.Messages.Add(new MessageViewModel
                {
                    Id = message.Id,
                    Image = "data:image/jpeg;base64," + Convert.ToBase64String(_userLogic.GetProfilePicture(message.UserId), 0, _userLogic.GetProfilePicture(message.UserId).Length),
                    Username = _userLogic.GetUser(message.UserId).Username,
                    Text = message.Text,
                    PostedAt = message.PostedAt
                });
            }

            foreach (IProgression progression in allProgressions.OrderByDescending(p => p.Date).ToList())
            {
                viewModel.Progressions.Add(new ProgressionViewModel
                {
                    ProgressPicture = "data:/image/jpeg;base64," + Convert.ToBase64String(progression.ProgressPicture, 0, progression.ProgressPicture.Length),
                    Bodyweight = progression.Bodyweight,
                    Date = progression.Date,
                    Username = _userLogic.GetUser(progression.UserId).Username,
                    Id = progression.Id,
                });
            }

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult UserProfile(int userId)
        {
            var currentUser = _userLogic.GetUser(User.Identity.Name);
            string profileProfilePicture = "data:image/jpeg;base64," + Convert.ToBase64String(_userLogic.GetProfilePicture(userId), 0, _userLogic.GetProfilePicture(userId).Length);
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
            if (searchInput == null)
            {
                TempData["error-feedback"] = $"No username given, try again!";
                return RedirectToAction("Index", "User");
            }

            if (_userLogic.GetUser(searchInput.Trim()) == null)
            {
                TempData["error-feedback"] = $"No user found with the username {searchInput.Trim()}";
                return RedirectToAction("Index", "User");
            }

            return RedirectToAction("UserProfile", "User", new { userId = _userLogic.GetUser(searchInput).Id });
        }

        [HttpGet]
        public IActionResult EditProfile()
        {
            var currentUser = _userLogic.GetUser(User.Identity.Name);
            var pvm = new ProfileViewModel
            {
                Firstname = currentUser.Firstname,
                Lastname = currentUser.Lastname,
                Username = currentUser.Username,
                Password = currentUser.Password
            };
            return View(pvm);
        }

        [HttpPost]
        public IActionResult EditProfile(IFormFile picture, string username, string firstname, string lastname, string password)
        {
            var currentUser = _userLogic.GetUser(User.Identity.Name);

            if (picture != null)
            {
                using var rs = picture.OpenReadStream();
                using var ms = new MemoryStream();
                rs.CopyTo(ms);
                currentUser.ProfilePicture = ms.ToArray();
            }

            currentUser.Username = username;
            currentUser.Firstname = firstname;
            currentUser.Lastname = lastname;
            currentUser.Password = password;

            if (_userLogic.UpdateProfile(currentUser))
            {
                TempData["success-feedback"] = $"Profile updated successfully!";
                return RedirectToAction("UserProfile", "User", new { userId = currentUser.Id });
            }

            TempData["error-feedback"] = $"No changes made";
            return RedirectToAction("UserProfile", "User", new { userId = currentUser.Id });


        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Home");
        }

        // TODO, *IF TIME LEFT*
        //public IActionResult EditUser(string username, IFormFile profilepic)
        //{
        //    var currentUser = _userLogic.GetUser(User.Identity.Name);

        //    var user = ModelFactory.CreateUser();
        //    {
        //        user.Id = currentUser.Id;
        //        user.ProfilePicture = currentUser.ProfilePicture;
        //        user.Username = currentUser.Username;
        //    }

        //    if (username != null && profilepic == null)
        //    {
        //        user.Username = username;
        //        _userLogic.UpdateProfile(user);
        //    }

        //    if (profilepic != null && username == null)
        //    {
        //        using (var rs = profilepic.OpenReadStream())
        //        using (var ms = new MemoryStream())
        //        {
        //            rs.CopyTo(ms);
        //            user.ProfilePicture = ms.ToArray();
        //            _userLogic.UpdateProfile(user);
        //        }
        //    }

        //    if (username == null || profilepic == null) return;
        //    {
        //        user.Username = username;
        //        using (var rs = profilepic.OpenReadStream())
        //        using (var ms = new MemoryStream())
        //        {
        //            rs.CopyTo(ms);
        //            user.ProfilePicture = ms.ToArray();
        //            _userLogic.UpdateProfile(user);
        //        }
        //        _userLogic.UpdateProfile(user);
        //    }
        //}
        //public IActionResult UserProfile(int userId, int likerId)
        //{
        //    var currentUser = _userLogic.GetUser(User.Identity.Name);
        //    int followerId = currentUser.Id;
        //    userId = (int)TempData["userId"];


        //    ViewData["likestatus"] = null;

        //    if (!_userLogic.IsFollowing(userId, followerId))
        //    {
        //        ViewData["likestatus"] = "LIKE";
        //        _userLogic.Like(userId, currentUser.Id);
        //        TempData["success-feedback"] = $"{_userLogic.GetUser(userId).Firstname} {_userLogic.GetUser(userId).Lastname} liked successfully!";
        //        return RedirectToAction("Index", "User");
        //    }

        //    if (!_userLogic.AlreadyLiked(userId, followerId))
        //    {

        //    }
        //    ViewData["likestatus"] = "DISLIKE";
        //    _userLogic.Dislike(userId, followerId);
        //    TempData["success-feedback"] = $"{_userLogic.GetUser(userId).Firstname} {_userLogic.GetUser(userId).Lastname} disliked successfully!";
        //    return RedirectToAction("Index", "User");
        //}
    }
}