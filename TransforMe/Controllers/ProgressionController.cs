using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransforMe.BLLFactory;
using TransforMe.Interface;
using TransforMe.Interface.Logics;
using TransforMe.ViewModels;

namespace TransforMe.Controllers
{
    public class ProgressionController : Controller
    {
        private readonly IUserLogic _userLogic;

        public ProgressionController()
        {
            _userLogic = LogicFactory.CreateUserLogic();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var currentUser = _userLogic.GetUser(User.Identity.Name);
            List<ProgressionViewModel> pvm = new List<ProgressionViewModel>();

            foreach (IProgression progression in _userLogic.GetProgressionsByUserId(currentUser.Id))
            {
                pvm.Add(new ProgressionViewModel
                {
                    ProgressPicture = "data:/image/jpeg;base64," + Convert.ToBase64String(progression.ProgressPicture, 0, progression.ProgressPicture.Length),
                    Bodyweight = progression.Bodyweight,
                    Date = progression.Date,
                    Username = _userLogic.GetUser(currentUser.Id).Username,
                    Id = _userLogic.GetUser(currentUser.Id).Id
                });
            }

            return View(pvm);
        }

        [HttpPost]
        public IActionResult Index(IFormFile picture, decimal bodyweight, DateTime date)
        {
            var currentUser = _userLogic.GetUser(User.Identity.Name);

            var pvm = new ProgressionViewModel();
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
                    return RedirectToAction("Index", "Progression");
                }
                else
                {
                    TempData["error-feedback"] = "Failed to add progressions, something went wrong!";
                    return RedirectToAction("Index", "Progression");
                }
            }

            TempData["error-feedback"] = "Either one (if not more) of the required input fields is empty or the date is not valid!";
            return RedirectToAction("Index", "Progression");

        }

        public IActionResult DeleteProgression(int progressionId)
        {
            // TODO: Delete progression must be implemented still
            if (_userLogic.DeleteProgression(progressionId))
            {
                TempData["success-feedback"] = $"Progression has been deleted successfully!";
                return RedirectToAction("Index", "Progression");
            }

            return RedirectToAction("Index", "User");
        }
    }
}