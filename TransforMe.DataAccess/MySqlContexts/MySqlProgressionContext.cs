using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TransforMe.DataAccess.Models;
using TransforMe.DataAccess.Utilities;
using TransforMe.Interface;
using TransforMe.Interface.Contexts;

namespace TransforMe.DataAccess
{
    public class MySqlProgressionContext : IProgressionContext
    {
        public bool Create(IProgression progression, int userId)
        {
            using MySqlConnection conn = new MySqlConnection(ConnectionUtility.MySqlConnectionString);
            MySqlCommand cmd = new MySqlCommand("spAddProgression", conn);
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Picture", progression.ProgressPicture);
            cmd.Parameters.AddWithValue("@Bodyweight", progression.Bodyweight);
            cmd.Parameters.AddWithValue("@Date", progression.Date);
            cmd.Parameters.AddWithValue("@UserId", userId);

            cmd.ExecuteNonQuery();
            conn.Close();

            return true;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IProgression Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProgression> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProgression> GetAll(int userId)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionUtility.MySqlConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("spGetProgressionsByUserId", conn);
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", userId);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                List<IProgression> progressionsToReturn = new List<IProgression>();

                while (dataReader.Read())
                {
                    IProgression progression = new DtoProgression
                    {
                        Id = Convert.ToInt32(dataReader["id"]),
                        ProgressPicture = dataReader["progresspicture"] as byte[],
                        Bodyweight = Convert.ToDecimal(dataReader["bodyweight"]),
                        Date = (DateTime)dataReader["date"]
                    };
                    progressionsToReturn.Add(progression);
                }

                return progressionsToReturn;
            }
        }

        public IEnumerable<IProgression> GetAllFromFollowings(int userId)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionUtility.MySqlConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("spGetProgressionsFromFollowingsById", conn);
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", userId);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                List<IProgression> progressionsToReturn = new List<IProgression>();

                while (dataReader.Read())
                {
                    IProgression message = new DtoProgression
                    {
                        ProgressPicture = dataReader["progresspicture"] as byte[],
                        Bodyweight = Convert.ToInt32(dataReader["bodyweight"]),
                        Date = (DateTime)dataReader["date"],
                        UserId = Convert.ToInt32(dataReader["user_id"])
                    };

                    progressionsToReturn.Add(message);
                }

                return progressionsToReturn;
            }
        }
    }
}
