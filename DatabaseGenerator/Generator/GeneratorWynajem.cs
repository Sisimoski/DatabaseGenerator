using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DatabaseGenerator.Model;
using Oracle.ManagedDataAccess.Client;

namespace DatabaseGenerator
{
    public class GeneratorWynajem
    {
        public GeneratorWynajem()
        {
        }

        public static int SelectLastID()
        {
            string command = $"SELECT NVL(MAX(id_wynajem), 0) FROM wynajem";

            OracleCommand cmd = new OracleCommand(command, DatabaseConnection.connection);
            int lastID = Convert.ToInt32(cmd.ExecuteScalar());
            return lastID;
        }

        public static void GenerateWynajemValues()
        {
            if (GeneratorSamochod.CheckIfSamochodHasAnyRows() == true && GeneratorKlient.SelectLastID() > 0 && GeneratorPlatnosc.SelectLastID() > 0)
            {
                TableSamochod.AddVINsToArray();
                int rowsInserted = 0;

                Console.Write("Wprowadź ilość wierszy do INSERT: ");
                int rowsToInsert = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < rowsToInsert; i++)
                {
                    string vinLosowe = TableSamochod.VINs[Generator.random.Next(0, TableSamochod.VINs.Length)];
                    int idklientLosowe = Generator.random.Next(1, GeneratorKlient.SelectLastID());
                    int idplatnoscLosowe = Generator.random.Next(1, GeneratorPlatnosc.SelectLastID());
                    string dataWynajmuLosowe = TableWynajem.DataWynajmu;
                    string dataZwrotuLosowe = TableWynajem.DataZwrotu;

                    string command = $"INSERT INTO wynajem(vin, id_klienta, id_platnosc, data_wynajmu, data_zwrotu) VALUES('{vinLosowe}', {idklientLosowe}, {idplatnoscLosowe}, '{dataWynajmuLosowe}', '{dataZwrotuLosowe}')";
                    string commandToWriteToFile = $"INSERT INTO wynajem(vin, id_klienta, id_platnosc, data_wynajmu, data_zwrotu) VALUES('{vinLosowe}', {idklientLosowe}, {idplatnoscLosowe}, '{dataWynajmuLosowe}', '{dataZwrotuLosowe}')" + "\n";

                    // This will get the current WORKING directory (i.e. \bin\Debug)
                    string workingDirectory = Environment.CurrentDirectory;
                    // or: Directory.GetCurrentDirectory() gives the same result

                    // This will get the current PROJECT directory
                    string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;

                    string fullFileName = $"{projectDirectory}/WynajemInserts.txt";

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
            else
            {
                Console.WriteLine("Nie można dodać do tabeli WYNAJEM. Nie istnieje żaden rekord w tabeli SAMOCHOD lub KLIENT lub PLATNOSC. Musisz najpierw wygenerować rekordy dla tabeli SAMOCHOD lub KLIENT lub PLATNOSC.");
            }
        }
    }
}
