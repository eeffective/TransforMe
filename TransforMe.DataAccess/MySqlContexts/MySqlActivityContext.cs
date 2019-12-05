using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TransforMe.DataAccess.Utilities;
using TransforMe.Interface;
using TransforMe.Interface.Contexts;

namespace TransforMe.DataAccess
{
    public class MySqlActivityContext : IActivityContext
    {
        public bool Create(IActivity activity, int userId)
        {
            using MySqlConnection conn = new MySqlConnection(ConnectionUtility.MySqlConnectionString);
            MySqlCommand cmd = new MySqlCommand("spAddActivity", conn);
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Date", activity.Date);
            cmd.Parameters.AddWithValue("@Description", activity.Description);
            cmd.Parameters.AddWithValue("@UserId", userId);

            cmd.ExecuteNonQuery();
            conn.Close();

            return true;
        }

        public IActivity Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IActivity> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IActivity> GetAll(int userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IActivity> GetAll(string username)
        {
            throw new NotImplementedException();
        }
    }
}
