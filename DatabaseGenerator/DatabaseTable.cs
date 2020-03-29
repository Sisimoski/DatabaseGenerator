using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;

namespace DatabaseGenerator
{
    public class DatabaseTable
    {
        int index = 0;

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

                Console.WriteLine("Dostępne tabele: ");
                foreach (string item in TableList)
                {
                    index++;
                    Console.WriteLine($"#{index}: {item}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
