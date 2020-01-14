using System;
using System.Collections.Generic;
using System.Text;

namespace TransforMe.Interface.Contexts
{
    public interface IUserContext
    {
        IUser Get(int id);
        IUser Get(string username);
        IEnumerable<IUser> GetAll();
        bool Create(IUser user);
        bool Update(IUser user);
        bool Delete(int id);
        int GetFollowersAmount(int userId);
        int GetFollowingsAmount(int userId);
        int GetLikesAmount(int userId);
        List<string> GetAllQuestions();
        bool DoIFollowUser(int userId, int likerId);
        bool DoILikeUser(int userId, int followerId);
        int GetQuestionId(string question);
        bool FollowUser(int userId, int followerId);
        bool LikeUser(int userId, int likerId);
        bool UnfollowUser(int userId, int followerId);
        bool DislikeUser(int userId, int likerId);
        List<IUser> GetTopFive();
    }
}
