using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using TransforMe.DataAccess.Utilities;

namespace TransforMe.DataAccess.Factory
{
    public static class MySqlConnectionFactory
    {
        public static MySqlConnection CreateConnection() => new MySqlConnection(ConnectionUtility.MySqlConnectionString);
    }
}
