using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLCodeGenerator.Database
{
    internal class clsDataAccessSettings
    {

        public static string ConnectionString = "Server=.\\SA;Database=AFPS;User Id=sa;Password=123456";

        public static DataTable GetAllDatabase()
        {
            string connectionString =@"Server=.;Integrated Security=True;";
            SqlConnection Conn=new SqlConnection(connectionString);
            DataTable _dt=new DataTable();
            string query = @"select name from sys.Databases
order by name";
            SqlCommand cmd=new SqlCommand(query, Conn);
            try
            {
                Conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                { 
                _dt.Load(reader);
                
                }
            }
            catch (Exception)
            {

                throw;
            }
            return _dt;
        }
    }
}
