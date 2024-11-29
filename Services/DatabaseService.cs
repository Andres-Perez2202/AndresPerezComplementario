using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AndresPerezComplementario.Services
{
    public class DatabaseService
    {
        private readonly string connectionString = "Server=localhost;Database=DBUISSAEL;User=root;Password=;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
