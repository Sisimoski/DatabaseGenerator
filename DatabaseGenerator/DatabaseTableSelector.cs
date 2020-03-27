using System;
using Oracle.ManagedDataAccess.Client;

namespace DatabaseGenerator
{
    public class DatabaseTableSelector : DatabaseHandler
    {
        public DatabaseTableSelector()
        {
        }

        public void SelectTables()
        {

            using OracleCommand cmd = DatabaseConnection.connection.CreateCommand();
            try
            {
                cmd.BindByName = true;
                cmd.CommandText = "select table_name from user_tables";

                //Execute the command and use DataReader to display the data
                OracleDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("Lista tabel: ");
                while (reader.Read())
                {
                    Console.WriteLine("Tabela: " + reader.GetString(0));
                }

                Console.WriteLine();
                Console.WriteLine("Press 'Enter' to continue");

                reader.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
