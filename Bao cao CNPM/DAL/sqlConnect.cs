using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class sqlConnect
    {
        protected static string _connectionString;

        protected SqlConnection connection;
        protected SqlDataAdapter adapter;
        protected SqlCommand command;

        //public string ConnectionString = @"Data Source=emthichhocit94;Initial Catalog=RAPCHIEUPHIM;Integrated Security=True";
        public string ConnectionString = @"Data Source=SPACE\SQLEXPRESS;Initial Catalog=QLRAPCHIEUPHIM;Integrated Security=True";

        public void connect()
        {
            connection = new SqlConnection(ConnectionString);

            connection.Open();
            executeNonQuery("set dateformat ymd");
        }

        public void disconnect()
        {
            connection.Close();
        }

        public IDataReader executeQueryParameter(string sqlString, List<SqlParameter> List_para)
        {

            command = new SqlCommand(sqlString, connection);
            command.CommandType = CommandType.StoredProcedure;

            foreach (SqlParameter para in List_para)
            {
                command.Parameters.Add(para);
            }

            return command.ExecuteReader();
        }

        public IDataReader executeQuery(string sqlString)
        {
            command = new SqlCommand(sqlString, connection);
            command.CommandType = CommandType.StoredProcedure;
            return command.ExecuteReader();
        }

        public void executeNonQuery(string sqlString)
        {
            command = new SqlCommand(sqlString, connection);
            //command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
        }

        public object executeScalar(string sqlString)
        {
            command = new SqlCommand(sqlString, connection);
            return command.ExecuteScalar();
        }
    }
}
