using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DatabaseGenerator.Model;
using Oracle.ManagedDataAccess.Client;

namespace DatabaseGenerator
{
    public class GeneratorPracownicy
    {
        public GeneratorPracownicy()
        {
        }

        public static int SelectLastID()
        {
            string command = $"SELECT NVL(MAX(id_pracownik), 0) FROM pracownicy";

            OracleCommand cmd = new OracleCommand(command, DatabaseConnection.connection);
            int lastID = Convert.ToInt32(cmd.ExecuteScalar());
            return lastID;
        }

        public static void GenerateValuePracownik()
        {
            if (GeneratorOddzial.SelectLastID() > 0)
            {
                int rowsInserted = 0;

                Console.Write("Wprowadź ilość wierszy do INSERT: ");
                int rowsToInsert = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < rowsToInsert; i++)
                {
                    int idOddzialLosowe = Generator.random.Next(1, GeneratorOddzial.SelectLastID());
                    string imieLosowe = TablePracownicy.pracownicyImieValues[Generator.random.Next(0, TablePracownicy.pracownicyImieValues.Length)];
                    string nazwiskoLosowe = TablePracownicy.pracownicyNazwiskoValues[Generator.random.Next(0, TablePracownicy.pracownicyNazwiskoValues.Length)];
                    string emailLosowe = TableKlient.RandomizeEmailValue();
                    string numerTelefonuLosowe = TableKlient.RandomizePhoneNumber();

                    string command = $"INSERT INTO pracownicy(id_oddzial, imie, nazwisko, email, numer_telefonu) VALUES({idOddzialLosowe}, '{imieLosowe}', '{nazwiskoLosowe}', '{emailLosowe}', '{numerTelefonuLosowe}')";
                    string commandToWriteToFile = $"INSERT INTO pracownicy(id_oddzial, imie, nazwisko, email, numer_telefonu) VALUES({idOddzialLosowe}, '{imieLosowe}', '{nazwiskoLosowe}', '{emailLosowe}', '{numerTelefonuLosowe}')" + "\n";

                    // This will get the current WORKING directory (i.e. \bin\Debug)
                    string workingDirectory = Environment.CurrentDirectory;
                    // or: Directory.GetCurrentDirectory() gives the same result

                    // This will get the current PROJECT directory
                    string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;

                    string fullFileName = $"{projectDirectory}/PracownicyInserts.txt";

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
                Console.WriteLine("Nie można dodać do tabeli PRACOWNICY. Nie istnieje żaden rekord w tabeli ODDZIAL. Musisz najpierw wygenerować rekordy dla tabeli ODDZIAL.");
            }
        }
    }
}
