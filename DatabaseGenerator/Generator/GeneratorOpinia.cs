using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DatabaseGenerator.Model;
using Oracle.ManagedDataAccess.Client;

namespace DatabaseGenerator
{
    public class GeneratorOpinia
    {
        public GeneratorOpinia()
        {
        }

        public static int SelectLastID()
        {
            string command = $"SELECT NVL(MAX(id_opinia), 0) FROM opinia";

            OracleCommand cmd = new OracleCommand(command, DatabaseConnection.connection);
            int lastID = Convert.ToInt32(cmd.ExecuteScalar());
            return lastID;
        }

        public static void GenerateOpiniaValues()
        {
            if (GeneratorKlient.SelectLastID() > 0)
            {
                int rowsInserted = 0;

                Console.Write("Wprowadź ilość wierszy do INSERT: ");
                int rowsToInsert = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < rowsToInsert; i++)
                {
                    int idklientLosowe = Generator.random.Next(1, GeneratorKlient.SelectLastID());
                    int ocenaLosowe = TableOpinia.RandomizeRateValue();
                    string komentarzLosowe = TableOpinia.opiniaKomentarzValues[Generator.random.Next(0, TableOpinia.opiniaKomentarzValues.Length)];

                    string command = $"INSERT INTO opinia(id_klient, ocena, komentarz) VALUES({idklientLosowe}, {ocenaLosowe}, '{komentarzLosowe}')";
                    string commandToWriteToFile = $"INSERT INTO opinia(id_klient, ocena, komentarz) VALUES({idklientLosowe}, {ocenaLosowe}, '{komentarzLosowe}')" + "\n";

                    // This will get the current WORKING directory (i.e. \bin\Debug)
                    string workingDirectory = Environment.CurrentDirectory;
                    // or: Directory.GetCurrentDirectory() gives the same result

                    // This will get the current PROJECT directory
                    string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;

                    string fullFileName = $"{projectDirectory}/OpiniaInserts.txt";

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
                Console.WriteLine("Nie można dodać do tabeli OPINIA. Nie istnieje żaden rekord w tabeli KLIENT. Musisz najpierw wygenerować rekordy dla tabeli KLIENT.");
            }
        }
    }
}
