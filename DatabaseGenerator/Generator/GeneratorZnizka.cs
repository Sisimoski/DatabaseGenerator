using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DatabaseGenerator.Model;
using Oracle.ManagedDataAccess.Client;

namespace DatabaseGenerator
{
    public class GeneratorZnizka
    {
        public GeneratorZnizka()
        {
        }

        public static int SelectLastID()
        {
            string command = $"SELECT NVL(MAX(id_znizka), 0) FROM znizka";

            OracleCommand cmd = new OracleCommand(command, DatabaseConnection.connection);
            int lastID = Convert.ToInt32(cmd.ExecuteScalar());
            return lastID;
        }

        public static void GenerateZnizkaValues()
        {
            //TO JEST GOTOWE
            int rowsInserted = 0;

            Console.Write("Wprowadź ilość wierszy do INSERT: ");
            int rowsToInsert = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < rowsToInsert; i++)
            {
                string kodLosowe = TableZnizka.RandomizeKodZnizkowy();
                string opisLosowe = TableZnizka.Opis[Generator.random.Next(0, TableZnizka.Opis.Length)];

                string command = $"INSERT INTO znizka(kod, opis) VALUES('{kodLosowe}', '{opisLosowe}')";
                string commandToWriteToFile = $"INSERT INTO znizka(kod, opis) VALUES('{kodLosowe}', '{opisLosowe}')" + "\n";

                // This will get the current WORKING directory (i.e. \bin\Debug)
                string workingDirectory = Environment.CurrentDirectory;
                // or: Directory.GetCurrentDirectory() gives the same result

                // This will get the current PROJECT directory
                string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;

                string fullFileName = $"{projectDirectory}/ZnizkaInserts.txt";

                OracleCommand cmd = new OracleCommand(command, DatabaseConnection.connection);
                try
                {
                    cmd.ExecuteNonQuery();
                    File.AppendAllText(fullFileName, commandToWriteToFile);
                    rowsInserted++;

                }
                catch (Exception e)
                {
                    Console.WriteLine("Błąd: " + e.Message);
                }
                finally
                {
                    cmd.Dispose();
                }
            }
            Console.WriteLine("[{0}] Wierszy Wstawiono", rowsInserted);
        }
    }
}
