using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransforMe.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "This can't be empty.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "This can't be empty.")]
        public string Password { get; set; }
    }
}
