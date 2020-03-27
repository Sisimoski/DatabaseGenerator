using System;
using Oracle.ManagedDataAccess.Client;

namespace DatabaseGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Symulator SQL");
            Console.WriteLine("=============");

            var myConnection = new DatabaseConnection();
            var myTable = new DatabaseTableSelector();
            myConnection.ConnectToDatabase(true);
            myTable.SelectTables();

        }
    }
}
