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
        private readonly IUserContext _userContext;
        private readonly IMessageContext _messageContext;
        private readonly IProgressionContext _progressionContext;
        private readonly IActivityContext _activityContext;

        public UserLogic()
        {
            _userContext = ContextFactory.CreateUserContext();
            _messageContext = ContextFactory.CreateMessageContext();
            _progressionContext = ContextFactory.CreateProgressionContext();
            _activityContext = ContextFactory.CreateActivityContext();
        }

        public bool UpdateProfile(IUser user) => _userContext.Update(user);

        public bool PostMessage(IMessage message, int userId)
        {
            message.PostedAt = DateTime.Now;
            if (_messageContext.Create(message, userId))
            {
                return true;
            }
            return false;
        }

        public bool DeleteMessage(int messageId) => _messageContext.Delete(messageId);

        public bool DeleteProgression(int progressionId) => _progressionContext.Delete(progressionId);

        public bool PostProgression(IProgression progression, int userId) => _progressionContext.Create(progression, userId);

        public bool PlanActivity(IActivity activity, int userId) => _activityContext.Create(activity, userId);

        public bool Register(IUser user)
        {
            string defaultProfilePicture = @"C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\wwwroot\images\defaultprofilepicture.jpg";
            var imageToByte = File.ReadAllBytes(defaultProfilePicture);

            user.ProfilePicture = imageToByte;
            user.ActiveState = 1;
            user.AccountType = "Public";
            user.Role = 1;
            user.DateOfCreation = DateTime.Now;
            if (_userContext.Create(user))
            {
                return true;
            }
            return false;
        }

        public bool ValidateLogin(string username, string password)
        {
            IUser user = _userContext.Get(username);
            return user != null && user.Username == username && user.Password == password;
        }

        public int GetRole(string username) => _userContext.Get(username).Role;

        public IUser GetUser(int userId) => _userContext.Get(userId);

        public IUser GetUser(string username) => _userContext.Get(username);

        public byte[] GetProfilePicture(int userId) => _userContext.Get(userId).ProfilePicture;

        public IEnumerable<IMessage> GetFollowingsMessages(int userId) => _messageContext.GetAllFromFollowings(userId);

        public IEnumerable<IProgression> GetFollowingsProgressions(int userId) => _progressionContext.GetAllFromFollowings(userId);

        public int GetFollowersAmount(int userId) => _userContext.GetFollowersAmount(userId);

        public int GetFollowingAmount(int userId) => _userContext.GetFollowingsAmount(userId);

        public IEnumerable<IMessage> GetMessagesByUserId(int userId) => _messageContext.GetAllByUserId(userId);

        public IEnumerable<IProgression> GetProgressionsByUserId(int userId) => _progressionContext.GetAll(userId);

        public List<string> GetAllQuestions() => _userContext.GetAllQuestions();

        public int GetQuestionId(string question) => _userContext.GetQuestionId(question);

        public bool IsFollowing(int userId, int followerId) => _userContext.DoIFollowUser(userId, followerId);

        public bool AlreadyLiked(int userId, int likerId) => _userContext.DoILikeUser(userId, likerId);

        public bool Follow(int userId, int followerId) => _userContext.FollowUser(userId, followerId);

        public bool Like(int userId, int likerId) => _userContext.LikeUser(userId, likerId);

        public bool Unfollow(int userId, int followerId) => _userContext.UnfollowUser(userId, followerId);

        public bool Dislike(int userId, int dislikerId) => _userContext.DislikeUser(userId, dislikerId);
    }
}
