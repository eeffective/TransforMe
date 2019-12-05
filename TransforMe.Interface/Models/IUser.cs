using System;

namespace TransforMe.Interface
{
    public interface IUser
    {
        int Id { get; set; }
        string Firstname { get; set; }
        string Lastname { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        int SecurityQuestion { get; set; }
        string SecurityAnswer { get; set; }
        int ActiveState { get; set; }
        string AccountType { get; set; }
        byte[] ProfilePicture { get; set; }
        DateTime DateOfCreation { get; set; }
        int Role { get; set; }
    }
}
