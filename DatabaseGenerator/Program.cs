using System;

namespace DatabaseGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Symulator SQL");
            Console.WriteLine("=============");

            var myConnection = new DatabaseConnection();
            myConnection.ConnectToDatabase(true);
            var myTable = new DatabaseTable();
            myTable.SelectTables();



            //var myGenerator = new Generator();
            //myGenerator.Generate();
        }
    }
}
