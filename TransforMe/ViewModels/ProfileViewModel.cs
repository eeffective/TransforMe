using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransforMe.ViewModels
{
    public class ProfileViewModel
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Followers { get; set; }
        public int Following { get; set; }
        public string ProfilePicture { get; set; }
        public List<MessageViewModel> Messages { get; set; }
        public List<ProgressionViewModel> Progressions { get; set; }
    }
}
