using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DatabaseGenerator.Model;
using Oracle.ManagedDataAccess.Client;

namespace DatabaseGenerator
{
    public class GeneratorSamochod
    {
        public GeneratorSamochod()
        {
        }

        public static bool CheckIfSamochodHasAnyRows()
        {
            string command = $"SELECT vin FROM samochod";
            OracleCommand cmd = new OracleCommand(command, DatabaseConnection.connection);
            OracleDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Dispose();
                return true;
            }
            else
            {
                reader.Dispose();
                return false;
            }
        }

        public static void PutVINsToList()
        {
            string command = $"SELECT vin FROM samochod";
            OracleCommand cmd = new OracleCommand(command, DatabaseConnection.connection);
            OracleDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TableSamochod.ListOfVINs.Add(reader.GetString(0));
                }
                reader.Dispose();
            }
        }

        public static void GenerateSamochodValues()
        {
            try
            {
                if (GeneratorSpecyfikacjaSamochodu.SelectLastID() > 0)
                {
                    int rowsInserted = 0;

                    Console.Write("Wprowadź ilość wierszy do INSERT: ");
                    int rowsToInsert = int.Parse(Console.ReadLine());

                    for (int i = 0; i < rowsToInsert; i++)
                    {
                        string vinLosowe = TableSamochod.RandomizeVIN();
                        int idspecyfikacjaLosowe = Generator.random.Next(1, GeneratorSpecyfikacjaSamochodu.SelectLastID());
                        string tablicaLosowe = TableSamochod.RandomizeTablicaRejestracyjna();

                        string command = $"INSERT INTO samochod(vin, id_specyfikacja_samochodu, numer_tablicy_rejestracyjnej) VALUES('{vinLosowe}', {idspecyfikacjaLosowe}, '{tablicaLosowe}')";
                        string commandToWriteToFile = $"INSERT INTO samochod(vin, id_specyfikacja_samochodu, numer_tablicy_rejestracyjnej) VALUES('{vinLosowe}', {idspecyfikacjaLosowe}, '{tablicaLosowe}')" + "\n";

                        // This will get the current WORKING directory (i.e. \bin\Debug)
                        string workingDirectory = Environment.CurrentDirectory;
                        // or: Directory.GetCurrentDirectory() gives the same result

                        // This will get the current PROJECT directory
                        string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;

                        string fullFileName = $"{projectDirectory}/SamochodInserts.txt";

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
                    Console.WriteLine("Nie można dodać do tabeli SAMOCHOD. Nie istnieje żaden rekord w tabeli SPECYFIKACJA_SAMOCHODU. Musisz najpierw wygenerować rekordy dla tabeli SPECYFIKACJA_SAMOCHODU.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Wprowadzono zły znak. Spróbuj ponownie.");
            }
        }
    }
}
