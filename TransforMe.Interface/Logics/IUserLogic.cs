﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TransforMe.Interface.Logics
{
    public interface IUserLogic
    {
        bool Register(IUser user);
        bool ValidateLogin(string username, string password);
        bool UpdateProfile(IUser user);
        bool PostMessage(IMessage message, int userId);
        bool DeleteMessage(int messageId);
        bool DeleteProgression(int progressionId);
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
        int GetQuestionId(string question);
        bool IsFollowing(int userId, int followerId);
        bool AlreadyLiked(int userId, int likerId);
        bool Follow(int userId, int followerId);
        bool Like(int userId, int likerId);
        bool Unfollow(int userId, int followerId);
        bool Dislike(int userId, int dislikerId);
    }
}
