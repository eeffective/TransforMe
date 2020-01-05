using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TransforMe.DataAccess.Factory;
using TransforMe.DataAccess.Models;
using TransforMe.DataAccess.Utilities;
using TransforMe.Interface;
using TransforMe.Interface.Contexts;

namespace TransforMe.DataAccess
{

    public class MySqlMessageContext : IMessageContext
    {
        public bool Create(IMessage message, int userId)
        {
            using MySqlConnection conn = MySqlConnectionFactory.CreateConnection();
            MySqlCommand cmd = new MySqlCommand("spAddMessage", conn);
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Text", message.Text);
            cmd.Parameters.AddWithValue("@PostedAt", message.PostedAt);
            cmd.Parameters.AddWithValue("@UserId", userId);

            cmd.ExecuteNonQuery();
            conn.Close();

            return true;
        }

        public bool Delete(int id)
        {
            using (MySqlConnection conn = MySqlConnectionFactory.CreateConnection())
            {
                MySqlCommand cmd = new MySqlCommand($"DELETE FROM messages WHERE messages.id = {id}", conn);
                conn.Open();
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                conn.Close();

                return true;
            }
        }

        public IMessage Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IMessage> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IMessage> GetAllByUserId(int userId)
        {
            using (MySqlConnection conn = MySqlConnectionFactory.CreateConnection())
            {
                MySqlCommand cmd = new MySqlCommand("spGetMessagesByUserId", conn);
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", userId);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                List<IMessage> messagesToReturn = new List<IMessage>();

                while (dataReader.Read())
                {
                    IMessage message = new DtoMessage
                    {
                        Id = Convert.ToInt32(dataReader["id"]),
                        Text = dataReader["text"].ToString(),
                        PostedAt = (DateTime)dataReader["postedat"],
                    };
                    messagesToReturn.Add(message);
                }

                return messagesToReturn;
            }
        }

        public IEnumerable<IMessage> GetAllByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IMessage> GetAllFromFollowings(int userId)
        {
            using (MySqlConnection conn = MySqlConnectionFactory.CreateConnection())
            {
                MySqlCommand cmd = new MySqlCommand("spGetMessagesFromFollowingsById", conn);
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", userId);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                List<IMessage> messagesToReturn = new List<IMessage>();

                while (dataReader.Read())
                {
                    IMessage message = new DtoMessage
                    {
                        Text = dataReader["text"].ToString(),
                        PostedAt = (DateTime)dataReader["postedat"],
                        UserId = Convert.ToInt32(dataReader["user_id"])
                    };

                    messagesToReturn.Add(message);
                }

                return messagesToReturn;
            }
        }

        public IEnumerable<IMessage> GetAllFromFollowings(string username)
        {
            throw new NotImplementedException();
        }
    }
}

