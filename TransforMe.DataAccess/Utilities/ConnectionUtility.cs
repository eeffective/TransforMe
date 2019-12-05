using System;
using System.Collections.Generic;
using System.Text;

namespace TransforMe.DataAccess.Utilities
{
    public class ConnectionUtility
    {
        public static string MySqlConnectionString { get; private set; }

        public ConnectionUtility(string connectionString)
        {
            MySqlConnectionString = connectionString;
        }
    }
}
