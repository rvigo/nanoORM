using System.Configuration;
using System.Data.SqlClient;

namespace nanoORM.ConnectionUtils
{
    public class ConnectionUtil
    {
        public static (SqlConnection conn, SqlCommand cmd) ConnectionProvider()
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(ConnectionString);

            return (conn, cmd);
        }

        private static string ConnectionString => ConfigurationManager.ConnectionStrings["nanoORM"].ConnectionString;
    }


}
