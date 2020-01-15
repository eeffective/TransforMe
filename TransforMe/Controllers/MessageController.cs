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
    public class MessageController : Controller
    {
        private readonly IUserLogic _userLogic;
        public MessageController()
        {
            _userLogic = LogicFactory.CreateUserLogic();
        }

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
    }
}