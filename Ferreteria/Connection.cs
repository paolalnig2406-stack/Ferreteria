using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace Ferreteria
{
    public class Connection
    {
        private string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Ferreteria;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;";
        private SqlConnection sqlConnection;

        public Connection()
        {
            sqlConnection = new SqlConnection(ConnectionString);

        }
        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }
    }
}
