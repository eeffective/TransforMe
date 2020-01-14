using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using TransforMe.DataAccess.Factory;
using TransforMe.DataAccess.Models;
using TransforMe.DataAccess.Utilities;
using TransforMe.Interface;
using TransforMe.Interface.Contexts;

namespace TransforMe.DataAccess
{
    public class MySqlUserContext : IUserContext
    {
        public bool Create(IUser user)
        {
            using MySqlConnection conn = MySqlConnectionFactory.CreateConnection();
            MySqlCommand cmd = new MySqlCommand("spAddUser", conn);
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Firstname", user.Firstname);
            cmd.Parameters.AddWithValue("@Lastname", user.Lastname);
            cmd.Parameters.AddWithValue("@Username", user.Username);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@SecurityQuestion", user.SecurityQuestion);
            cmd.Parameters.AddWithValue("@SecurityAnswer", user.SecurityAnswer);
            cmd.Parameters.AddWithValue("@ProfilePicture", user.ProfilePicture);
            cmd.Parameters.AddWithValue("@DateOfCreation", user.DateOfCreation);

            cmd.ExecuteNonQuery();
            conn.Close();

            return true;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IUser Get(int id)
        {
            using (MySqlConnection conn = MySqlConnectionFactory.CreateConnection())
            {
                MySqlCommand cmd = new MySqlCommand("spGetUserById", conn);
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", id);

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    IUser userToReturn = new DtoUser()
                    {
                        Id = Convert.ToInt32(dataReader["id"]),
                        Firstname = dataReader["firstname"].ToString(),
                        Lastname = dataReader["lastname"].ToString(),
                        Username = dataReader["username"].ToString(),
                        Password = dataReader["password"].ToString(),
                        SecurityQuestion = Convert.ToInt32(dataReader["securityquestion_id"]),
                        SecurityAnswer = dataReader["securityanswer"].ToString(),
                        ProfilePicture = dataReader.GetValue(7) as byte[],
                        ActiveState = Convert.ToInt32(dataReader["activestate"]),
                        AccountType = dataReader["securityquestion_id"].ToString(),
                        DateOfCreation = (DateTime)dataReader["dateofcreation"],
                        Role = Convert.ToInt32(dataReader["role"]),
                    };
                    return userToReturn;
                }
            }
            return null;
        }

        public IUser Get(string username)
        {
            using (MySqlConnection conn = MySqlConnectionFactory.CreateConnection())
            {
                MySqlCommand cmd = new MySqlCommand("spGetUserByUsername", conn);
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", username);

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    IUser userToReturn = new DtoUser()
                    {
                        Id = Convert.ToInt32(dataReader["id"]),
                        Firstname = dataReader["firstname"].ToString(),
                        Lastname = dataReader["lastname"].ToString(),
                        Username = dataReader["username"].ToString(),
                        Password = dataReader["password"].ToString(),
                        SecurityQuestion = Convert.ToInt32(dataReader["securityquestion_id"]),
                        SecurityAnswer = dataReader["securityanswer"].ToString(),
                        ProfilePicture = dataReader.GetValue(7) as byte[],
                        ActiveState = Convert.ToInt32(dataReader["activestate"]),
                        AccountType = dataReader["securityquestion_id"].ToString(),
                        DateOfCreation = (DateTime)dataReader["dateofcreation"],
                        Role = Convert.ToInt32(dataReader["role"]),
                    };
                    return userToReturn;
                }
            }
            return null;
        }

        public IEnumerable<IUser> GetAll()
        {
            using MySqlConnection conn = MySqlConnectionFactory.CreateConnection();
            MySqlCommand cmd = new MySqlCommand("spGetAllUsers", conn);
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            MySqlDataReader dataReader = cmd.ExecuteReader();

            var usersToReturn = new List<IUser>();

            while (dataReader.Read())
            {
                IUser user = new DtoUser
                {
                    Id = Convert.ToInt32(dataReader["id"]),
                    Firstname = dataReader["firstname"].ToString(),
                    Lastname = dataReader["lastname"].ToString(),
                    Username = dataReader["username"].ToString(),
                    Password = dataReader["password"].ToString(),
                    SecurityQuestion = Convert.ToInt32(dataReader["securityquestion_id"]),
                    SecurityAnswer = dataReader["securityanswer"].ToString(),
                    ProfilePicture = dataReader["profilepicture"] as byte[],
                    ActiveState = Convert.ToInt32(dataReader["activestate"]),
                    AccountType = dataReader["accounttype"].ToString(),
                    DateOfCreation = (DateTime)(dataReader["dateofcreation"]),
                    Role = Convert.ToInt32(dataReader["role"])
                };

                usersToReturn.Add(user);
            }
            return usersToReturn;
        }

        public bool Update(IUser user)
        {
            using (MySqlConnection conn = MySqlConnectionFactory.CreateConnection())
            {
                MySqlCommand cmd = new MySqlCommand($"spUpdateUser", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("newpic", user.ProfilePicture);
                cmd.Parameters.AddWithValue("userId", user.Id);
                cmd.Parameters.AddWithValue("firstname", user.Firstname);
                cmd.Parameters.AddWithValue("lastname", user.Lastname);
                cmd.Parameters.AddWithValue("username", user.Username);
                cmd.Parameters.AddWithValue("password", user.Password);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
                conn.Close();

                return true;
            }
        }

        public int GetFollowersAmount(int userId)
        {
            using (MySqlConnection conn = MySqlConnectionFactory.CreateConnection())
            {
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) AS followers FROM user_follower WHERE user_id = '" + userId + "';", conn);
                conn.Open();
                cmd.CommandType = CommandType.Text;

                MySqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.Read())
                {
                    return dataReader.GetInt32("followers");
                }
                return -1;
            }
        }

        public int GetFollowingsAmount(int userId)
        {
            using (MySqlConnection conn = MySqlConnectionFactory.CreateConnection())
            {
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) AS followings FROM user_follower WHERE follower_id = '" + userId + "';", conn);
                conn.Open();
                cmd.CommandType = CommandType.Text;

                MySqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.Read())
                {
                    return dataReader.GetInt32("followings");
                }
                conn.Close();
                return -1;
            }
        }

        public int GetLikesAmount(int userId)
        {
            using (MySqlConnection conn = MySqlConnectionFactory.CreateConnection())
            {
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) AS likes FROM user_liker WHERE liker_id = '" + userId + "';", conn);
                conn.Open();
                cmd.CommandType = CommandType.Text;

                MySqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.Read())
                {
                    return dataReader.GetInt32("likes");
                }
                conn.Close();
                return -1;
            }
        }

        public List<string> GetAllQuestions()
        {
            List<string> returnQuestions = new List<string>();
            using (MySqlConnection conn = MySqlConnectionFactory.CreateConnection())
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM securityquestions", conn);
                conn.Open();
                cmd.CommandType = CommandType.Text;

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    string question = dataReader["question"].ToString();
                    returnQuestions.Add(question);
                }

                return returnQuestions;
            }
        }

        public bool DoIFollowUser(int userId, int followerId)
        {
            int result = 0;
            using (MySqlConnection conn = MySqlConnectionFactory.CreateConnection())
            {
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) AS isFollowing FROM user_follower WHERE user_id = '" + userId + "' and follower_id = '" + followerId + "';", conn);
                conn.Open();
                cmd.CommandType = CommandType.Text;

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    result = Convert.ToInt32(dataReader["isFollowing"]);
                }
                conn.Close();
            }
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DoILikeUser(int userId, int likerId)
        {
            int result = 0;
            using (MySqlConnection conn = MySqlConnectionFactory.CreateConnection())
            {
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) AS alreadyLiked FROM user_liker WHERE user_id = '" + userId + "' and liker_id = '" + likerId + "';", conn);
                conn.Open();
                cmd.CommandType = CommandType.Text;

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    result = Convert.ToInt32(dataReader["alreadyLiked"]);
                }
                conn.Close();
            }
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetQuestionId(string question)
        {
            using (MySqlConnection conn = MySqlConnectionFactory.CreateConnection())
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM securityquestions WHERE question = '" + question + "'", conn);
                conn.Open();
                cmd.CommandType = CommandType.Text;

                MySqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.Read())
                {
                    int id = Convert.ToInt32(dataReader["id"]);
                    return id;
                }
                conn.Close();
                return -1;
            }
        }

        public bool FollowUser(int userId, int followerId)
        {
            using (MySqlConnection conn = MySqlConnectionFactory.CreateConnection())
            {
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO user_follower (`user_id`, `follower_id`) VALUES ({userId}, {followerId});", conn);
                conn.Open();
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                conn.Close();

                return true;
            }
        }

        public bool LikeUser(int userId, int likerId)
        {
            using (MySqlConnection conn = MySqlConnectionFactory.CreateConnection())
            {
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO user_liker (`user_id`, `liker_id`) VALUES ({userId}, {likerId});", conn);
                conn.Open();
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                conn.Close();

                return true;
            }
        }

        public bool UnfollowUser(int userId, int followerId)
        {
            using (MySqlConnection conn = MySqlConnectionFactory.CreateConnection())
            {
                MySqlCommand cmd = new MySqlCommand($"DELETE FROM user_follower WHERE user_id = {userId} AND follower_id = {followerId}", conn);
                conn.Open();
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                conn.Close();

                return true;
            }
        }

        public bool DislikeUser(int userId, int likerId)
        {
            using (MySqlConnection conn = MySqlConnectionFactory.CreateConnection())
            {
                MySqlCommand cmd = new MySqlCommand($"DELETE FROM user_liker WHERE user_id = {userId} AND liker_id = {likerId}", conn);
                conn.Open();
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                conn.Close();

                return true;
            }
        }

        public List<IUser> GetTopFive()
        {
            throw new NotImplementedException();
        }
    }
}
