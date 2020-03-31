using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;

namespace DatabaseGenerator
{
    public class DatabaseTable
    {
        public DatabaseTable()
        {
        }

        public static List<string> TableList { get; set; } = new List<string>();

        public static void SelectAllAvailableTables()
        {
            int index = 0;
            using OracleCommand cmd = DatabaseConnection.connection.CreateCommand();
            try
            {
                cmd.BindByName = true;
                cmd.CommandText = "select table_name from user_tables";

                OracleDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("\nDostępne tabele: ");
                while (reader.Read())
                {
                    index++;
                    Console.WriteLine($"\t#{index}: {reader.GetString(0)}");
                    TableList.Add(reader.GetString(0));
                }
                reader.Dispose();
                Console.WriteLine();

                //Console.WriteLine("Dostępne tabele: ");
                //foreach (string item in TableList)
                //{
                //    index++;
                //    Console.WriteLine($"\t#{index}: {item}");
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void SelectColumnNamesFromTable(string tableName)
        {
            int index = 0;
            using OracleCommand cmd = DatabaseConnection.connection.CreateCommand();
            try
            {
                cmd.BindByName = true;
                cmd.CommandText = $"select COLUMN_NAME from ALL_TAB_COLUMNS where TABLE_NAME='{tableName.ToUpper()}'";

                OracleDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("\nDostępne kolumny: ");
                while (reader.Read())
                {
                    index++;
                    Console.WriteLine($"\t#{index}: {reader.GetString(0)}");
                }
                reader.Dispose();
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void SelectQuery()
        {
            try
            {
                SelectAllAvailableTables();
                Console.Write($"Wprowadź nazwę tabeli: ");
                string tableName = Console.ReadLine();
                SelectColumnNamesFromTable(tableName);
                Console.Write($"Wprowadź nazwę kolumny: ");
                string columnName = Console.ReadLine();

                using OracleCommand cmd = DatabaseConnection.connection.CreateCommand();
                Console.WriteLine("Rezultat zapytania: ");
                cmd.CommandText = $"SELECT {columnName} FROM {tableName}";

                OracleDataReader reader = cmd.ExecuteReader();

                int index = 0;

                while (reader.Read())
                {
                    index++;
                    Console.WriteLine($"\t#{index}: {reader.GetString(0)}");
                }
                reader.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
