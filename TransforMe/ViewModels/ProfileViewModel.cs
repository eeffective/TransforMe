using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransforMe.ViewModels
{
    public class ProfileViewModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Followers { get; set; }
        public int Following { get; set; }
        public List<MessageViewModel> Messages { get; set; }
        public List<ProgressionViewModel> Progressions { get; set; }
    }
}
