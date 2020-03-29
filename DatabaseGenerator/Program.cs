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
            var myTable = new DatabaseTable();
            var myGenerator = new Generator();
            myConnection.ConnectToDatabase(true);
            myTable.SelectTables();
            myGenerator.Generate();
        }
    }
}
