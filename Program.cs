using System;
using System.Data.SqlClient;

namespace SQLServerSqlClientConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // butild connection string
                SqlConnectionStringBuilder builder = new();
                builder.DataSource = "10.0.2.4";
                builder.InitialCatalog = "pdb_ccms";
                builder.UserID = "mkharazi";
                builder.Password = "EdenredT123@";

                using SqlConnection connection = new(builder.ConnectionString);
                connection.Open();

                string sqlText = "select TxnCd, Descp from itx_TxnCode";
                using SqlCommand command = new(sqlText, connection);
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader.GetInt32(0)} -- {reader.GetString(1)}");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
