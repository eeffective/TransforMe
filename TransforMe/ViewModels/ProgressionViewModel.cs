using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransforMe.ViewModels
{
    public class ProgressionViewModel
    {
        public string Username { get; set; }
        [Display(Name = "Upload your picture here please.")]
        [Required(ErrorMessage = "There is no picture selected.")]
        public int Id { get; set; }
        public string ProgressPicture { get; set; }

        [Display(Name = "What was your current bodyweight?")]
        [Required(ErrorMessage = "This can't be empty.")]
        public decimal Bodyweight { get; set; }

        [Display(Name = "When was the picture taken?")]
        [Required(ErrorMessage = "This can't be empty.")]
        public DateTime Date { get; set; }
    }
}
