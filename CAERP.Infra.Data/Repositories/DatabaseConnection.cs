using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using CAERP.Domains.Interfaces;

namespace CAERP.Infra.Data.Repositories
{
    public class DatabaseConnection : IDatabaseConnection
    {
        public IDbConnection Connection { get; }

        public DatabaseConnection(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
        }

        public void Open()
        {
            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }
        }
    }
}
