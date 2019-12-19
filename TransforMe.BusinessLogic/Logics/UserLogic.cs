using System;
using System.Collections.Generic;
using System.IO;
using TransforMe.DALFactory;
using TransforMe.Interface;
using TransforMe.Interface.Contexts;
using TransforMe.Interface.Logics;

namespace TransforMe.BusinessLogic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserContext userContext = ContextFactory.CreateUserContext();
        private readonly IMessageContext messageContext = ContextFactory.CreateMessageContext();
        private readonly IProgressionContext progressionContext = ContextFactory.CreateProgressionContext();
        private readonly IActivityContext activityContext = ContextFactory.CreateActivityContext();

        public bool PostMessage(IMessage message, int userId)
        {
            message.PostedAt = DateTime.Now;
            if (messageContext.Create(message, userId))
            {
                return true;
            }
            return false;

        }

        public bool PostProgression(IProgression progression, int userId)
        {
            if (progressionContext.Create(progression, userId))
            {
                return true;
            }
            return false;
        }

        public bool PlanActivity(IActivity activity, int userId)
        {
            if (activityContext.Create(activity, userId))
            {
                return true;
            }
            return false;
        }

        public bool Register(IUser user)
        {
            //    string defaultProfilePicture = @"~\wwwroot\images\defaultprofilepicture.jpg";
            //    var imageToByte = File.ReadAllBytes(defaultProfilePicture);

            //user.ProfilePicture = imageToByte;
            user.ActiveState = 1;
            user.AccountType = "Public";
            user.Role = 1;
            user.DateOfCreation = DateTime.UtcNow;
            if (userContext.Create(user))
            {
                return true;
            }
            return false;
        }

        public bool ValidateLogin(string username, string password)
        {
            IUser user = userContext.Get(username);
            if (user != null && user.Username == username && user.Password == password)
            {
                return true;
            }
            return false;
        }

        public int GetRole(string username) => userContext.Get(username).Role;

        public IUser GetUser(int userId) => userContext.Get(userId);

        public IUser GetUser(string username) => userContext.Get(username);

        public byte[] GetProfilePicture(int userId) => userContext.Get(userId).ProfilePicture;

        public IEnumerable<IMessage> GetFollowingsMessages(int userId) => messageContext.GetAllFromFollowings(userId);

        public IEnumerable<IProgression> GetFollowingsProgressions(int userId) => progressionContext.GetAllFromFollowings(userId);

        public int GetFollowersAmount(int userId) => userContext.GetFollowersAmount(userId);

        public int GetFollowingAmount(int userId) => userContext.GetFollowingsAmount(userId);

        public IEnumerable<IMessage> GetMessagesByUserId(int userId) => messageContext.GetAllByUserId(userId);

        public IEnumerable<IProgression> GetProgressionsByUserId(int userId) => progressionContext.GetAll(userId);

        public List<string> GetAllQuestions() => userContext.GetAllQuestions();
        public int GetQuestionId(string question) => userContext.GetQuestionId(question);
    }
}
