using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransforMe.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "This can't be empty.")]
        [Display(Name = "First name")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "This can't be empty.")]
        [Display(Name = "Last name")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "This can't be empty.")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "This can't be empty.")]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "The password must be at least 8 characters long.", MinimumLength = 8)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Your password doesn't match.")]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "This can't be empty.")]
        [Display(Name = "Security question")]
        public int SecurityQuestion { get; set; }

        [Required(ErrorMessage = "This can't be empty.")]
        [Display(Name = "Security answer")]
        public string SecurityAnswer { get; set; }

        public List<string> SecurityQuestions { get; set; }

    }
}
