using System;
using System.Collections.Generic;
using System.Text;

namespace TransforMe.Interface.Logics
{
    public interface IUserLogic
    {
        bool Register(IUser user);
        bool ValidateLogin(string username, string password);
        bool PostMessage(IMessage message, int userId);
        bool PostProgression(IProgression progression, int userId);
        bool PlanActivity(IActivity activity, int userId);
        IEnumerable<IMessage> GetFollowingsMessages(int userId);
        IEnumerable<IMessage> GetMessagesByUserId(int userId);
        IEnumerable<IProgression> GetProgressionsByUserId(int userId);
        IEnumerable<IProgression> GetFollowingsProgressions(int userId);
        int GetRole(string username);
        IUser GetUser(int userId);
        IUser GetUser(string username);
        byte[] GetProfilePicture(int userId);
        int GetFollowersAmount(int userId);
        int GetFollowingAmount(int userId);
        List<string> GetAllQuestions();
    }
}
