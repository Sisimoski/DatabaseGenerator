using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;

namespace DatabaseGenerator
{
    public class DatabaseTable : DatabaseHandler
    {
        public DatabaseTable()
        {
        }

        public static List<string> TableList { get; set; } = new List<string>();

        public void SelectTables()
        {
            using OracleCommand cmd = DatabaseConnection.connection.CreateCommand();
            try
            {
                cmd.BindByName = true;
                cmd.CommandText = "select table_name from user_tables";

                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TableList.Add(reader.GetString(0));
                }

                reader.Dispose();

                Console.WriteLine("Lista tabel: ");
                foreach(string item in TableList)
                {
                    Console.WriteLine(item);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
