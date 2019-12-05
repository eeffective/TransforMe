using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransforMe.ViewModels
{
    public class MessageViewModel
    {
        public string Image { get; set; }
        public string Username { get; set; }
        [Required(ErrorMessage = "This can't be empty")]
        [StringLength(360, ErrorMessage ="This can't be longer than 360 characters")]
        public string Text { get; set; }
        public DateTime PostedAt { get; set; }
    }
}
