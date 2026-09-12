using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLCodeGenerator.Database
{
    public class clsDataAccessSettings
    {

        public static string ConnectionString { get;  set; } 

        public static DataTable GetAllDatabase()
        {
            string connectionString =
                @"Server=.\SA;Integrated Security=True;";

            SqlConnection Conn = new SqlConnection(connectionString);

            DataTable _dt = new DataTable();

            string query = @"
            SELECT name
            FROM sys.databases
            ORDER BY name";

            SqlCommand cmd = new SqlCommand(query, Conn);

            try
            {
                Conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                _dt.Load(reader);

                reader.Close();
                Conn.Close();
            }
            catch (Exception)
            {
                Conn.Close();
                throw;
            }

            return _dt;
        }
        public static bool TestConnection(
        string Server,
        string UserName,
        string Password,
        bool UseSQLAuthentication)
        {
            string Connection;

            if (UseSQLAuthentication)
            {
                Connection =
                    @"Server=" + Server +
                    @";User Id=" + UserName +
                    @";Password=" + Password +
                    @";Connect Timeout=3;";
            }
            else
            {
                Connection =
                    @"Server=" + Server +
                    @";Integrated Security=True;" +
                    @";Connect Timeout=3;";
            }

            SqlConnection Conn = new SqlConnection(Connection);

            try
            {
                Conn.Open();
                Conn.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
    }
