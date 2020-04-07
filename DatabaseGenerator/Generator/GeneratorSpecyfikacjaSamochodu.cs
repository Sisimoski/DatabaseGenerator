using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DatabaseGenerator.Model;
using Oracle.ManagedDataAccess.Client;

namespace DatabaseGenerator
{
    public class GeneratorSpecyfikacjaSamochodu
    {
        public GeneratorSpecyfikacjaSamochodu()
        {
        }

        public static int SelectLastID()
        {
            string command = $"SELECT NVL(MAX(id_specyfikacja_samochodu), 0) FROM specyfikacja_samochodu";

            OracleCommand cmd = new OracleCommand(command, DatabaseConnection.connection);
            int lastID = Convert.ToInt32(cmd.ExecuteScalar());
            return lastID;
        }

        public static void GenerateSpecyfikacjaSamochoduValues()
        {
            int rowsInserted = 0;

            Console.Write("Wprowadź ilość wierszy do INSERT: ");
            int rowsToInsert = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < rowsToInsert; i++)
            {
                string producentLosowe = TableSpecyfikacjaSamochodu.specyfikacjaSamochoduProducentValues[Generator.random.Next(0, TableSpecyfikacjaSamochodu.specyfikacjaSamochoduProducentValues.Length)];
                string modelLosowe = TableSpecyfikacjaSamochodu.specyfikacjaSamochoduModelValues[Generator.random.Next(0, TableSpecyfikacjaSamochodu.specyfikacjaSamochoduModelValues.Length)];
                string kolorLosowe = TableSpecyfikacjaSamochodu.specyfikacjaSamochoduKolorValues[Generator.random.Next(0, TableSpecyfikacjaSamochodu.specyfikacjaSamochoduKolorValues.Length)];
                int rokprodukcjiLosowe = TableSpecyfikacjaSamochodu.RandomizeSpecyfikacjaSamochoduDateValues();

                string command = $"INSERT INTO specyfikacja_samochodu(producent, model, rok, kolor) VALUES('{producentLosowe}', '{modelLosowe}', {rokprodukcjiLosowe}, '{kolorLosowe}')";
                string commandToWriteToFile = $"INSERT INTO specyfikacja_samochodu(producent, model, rok, kolor) VALUES('{producentLosowe}', '{modelLosowe}', {rokprodukcjiLosowe}, '{kolorLosowe}')" + "\n";

                // This will get the current WORKING directory (i.e. \bin\Debug)
                string workingDirectory = Environment.CurrentDirectory;
                // or: Directory.GetCurrentDirectory() gives the same result

                // This will get the current PROJECT directory
                string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;

                string fullFileName = $"{projectDirectory}/SpecyfikacjaSamochoduInserts.txt";

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
