using System;
using System.Collections.Generic;
using System.Text;
using TransforMe.Interface;

namespace TransforMe.BusinessLogic.Models
{
    public class User : IUser
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
        public int ActiveState { get; set; }
        public string AccountType { get; set; }
        public byte[] ProfilePicture { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int Role { get; set; }
    }
}
