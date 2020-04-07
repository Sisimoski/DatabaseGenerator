using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DatabaseGenerator.Model;
using Oracle.ManagedDataAccess.Client;

namespace DatabaseGenerator
{
    public class GeneratorPrzeglad
    {
        public GeneratorPrzeglad()
        {
        }

        public static int SelectLastID()
        {
            string command = $"SELECT NVL(MAX(id_przeglad), 0) FROM przeglad";

            OracleCommand cmd = new OracleCommand(command, DatabaseConnection.connection);
            int lastID = Convert.ToInt32(cmd.ExecuteScalar());
            return lastID;
        }

        public static void GeneratePrzegladValue()
        {
            if (GeneratorPracownicy.SelectLastID() > 0 && GeneratorSamochod.CheckIfSamochodHasAnyRows() == true)
            {
                TableSamochod.AddVINsToArray();
                int rowsInserted = 0;

                Console.Write("Wprowadź ilość wierszy do INSERT: ");
                int rowsToInsert = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < rowsToInsert; i++)
                {
                    int pracownikLosowe = Generator.random.Next(1, GeneratorPracownicy.SelectLastID());
                    string vinLosowe = TableSamochod.VINs[Generator.random.Next(0, TableSamochod.VINs.Length)];
                    string dataLosowe = TablePrzeglad.DataPrzegladu;
                    int przebiegLosowe = TablePrzeglad.RandomizePrzebiegValue();
                    int iloscPaliwaLosowe = TablePrzeglad.RandomizeIloscPaliwaValue();
                    string czyUszkodzonyLosowe = "n";

                    string command = $"INSERT INTO przeglad(id_pracownik, vin, data, przebieg, ilosc_paliwa_zasieg, czy_uszkodzony) VALUES({pracownikLosowe}, '{vinLosowe}', '{dataLosowe}', '{przebiegLosowe}', '{iloscPaliwaLosowe}', '{czyUszkodzonyLosowe}')";
                    string commandToWriteToFile = $"INSERT INTO przeglad(id_pracownik, vin, data, przebieg, ilosc_paliwa_zasieg, czy_uszkodzony) VALUES({pracownikLosowe}, '{vinLosowe}', '{dataLosowe}', '{przebiegLosowe}', '{iloscPaliwaLosowe}', '{czyUszkodzonyLosowe}')" + "\n";

                    // This will get the current WORKING directory (i.e. \bin\Debug)
                    string workingDirectory = Environment.CurrentDirectory;
                    // or: Directory.GetCurrentDirectory() gives the same result

                    // This will get the current PROJECT directory
                    string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;

                    string fullFileName = $"{projectDirectory}/PrzegladInserts.txt";

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
                Console.WriteLine("Nie można dodać do tabeli PRZEGLAD. Nie istnieje żaden rekord w tabeli PRACOWNIK lub SAMOCHOD. Musisz najpierw wygenerować rekordy dla tabeli PRACOWNIK lub SAMOCHOD.");
            }
        }
    }
}
