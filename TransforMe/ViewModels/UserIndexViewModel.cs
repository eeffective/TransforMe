using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransforMe.ViewModels
{
    public class UserIndexViewModel
    {
        public List<MessageViewModel> Messages { get; set; }
        public List<ProgressionViewModel> Progressions { get; set; }
        public MessageViewModel Message { get; set; }
    }
}
