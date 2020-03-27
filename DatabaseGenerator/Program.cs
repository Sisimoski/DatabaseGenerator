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

            Console.WriteLine("Co chcesz zrobić?");

            var myConnection = new DatabaseConnection();
            var myTable = new DatabaseTable();
            var myGenerator = new Generate();
            myConnection.ConnectToDatabase(true);
            myTable.SelectTables();
            myGenerator.Fill();
        }
    }
}
