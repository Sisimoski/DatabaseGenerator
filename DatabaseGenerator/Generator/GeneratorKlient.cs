using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DatabaseGenerator.Model;
using Oracle.ManagedDataAccess.Client;

namespace DatabaseGenerator
{
    public class GeneratorKlient
    {
        public GeneratorKlient()
        {
        }

        public static int SelectLastID()
        {
            string command = $"SELECT NVL(MAX(id_klient), 0) FROM klient";

            OracleCommand cmd = new OracleCommand(command, DatabaseConnection.connection);
            int lastID = Convert.ToInt32(cmd.ExecuteScalar());
            return lastID;
        }

        public static void GenerateValueKlient()
        {
            int rowsInserted = 0;

            Console.Write("Wprowadź ilość wierszy do INSERT: ");
            int rowsToInsert = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < rowsToInsert; i++)
            {
                string imieLosowe = TableKlient.klientImieValues[Generator.random.Next(0, TableKlient.klientImieValues.Length)];
                string nazwiskoLosowe = TableKlient.klientNazwiskoValues[Generator.random.Next(0, TableKlient.klientNazwiskoValues.Length)];
                string emailLosowe = TableKlient.RandomizeEmailValue();
                string numerTelefonuLosowe = TableKlient.RandomizePhoneNumber();
                string ulicaLosowe = TableKlient.oddzialUlicaValues[Generator.random.Next(0, TableKlient.oddzialUlicaValues.Length)];
                string miastoLosowe = TableKlient.oddzialMiastoValues[Generator.random.Next(0, TableKlient.oddzialMiastoValues.Length)];
                string wojewodztwoLosowe = TableKlient.oddzialWojewodztwoValues[Generator.random.Next(0, TableKlient.oddzialWojewodztwoValues.Length)];
                string kodpocztowyLosowe = TableKlient.RandomizeKodPocztowy();
                string numerprawajazdyLosowe = TableKlient.RandomizeNumerPrawaJazdy();
                string numerkartykredyowejLosowe = TableKlient.RandomizeNumerKartyKredytowej();

                string command = $"INSERT INTO klient(imie, nazwisko, email, numer_telefonu, ulica, miasto, wojewodztwo, kod_pocztowy, numer_prawa_jazdy, numer_karty_kredytowej) VALUES('{imieLosowe}', '{nazwiskoLosowe}', '{emailLosowe}', '{numerTelefonuLosowe}', '{ulicaLosowe}', '{miastoLosowe}', '{wojewodztwoLosowe}', '{kodpocztowyLosowe}', '{numerprawajazdyLosowe}', '{numerkartykredyowejLosowe}')";
                string commandToWriteToFile = $"INSERT INTO klient(imie, nazwisko, email, numer_telefonu, ulica, miasto, wojewodztwo, kod_pocztowy, numer_prawa_jazdy, numer_karty_kredytowej) VALUES('{imieLosowe}', '{nazwiskoLosowe}', '{emailLosowe}', '{numerTelefonuLosowe}', '{ulicaLosowe}', '{miastoLosowe}', '{wojewodztwoLosowe}', '{kodpocztowyLosowe}', '{numerprawajazdyLosowe}', '{numerkartykredyowejLosowe}')" + "\n";

                // This will get the current WORKING directory (i.e. \bin\Debug)
                string workingDirectory = Environment.CurrentDirectory;
                // or: Directory.GetCurrentDirectory() gives the same result

                // This will get the current PROJECT directory
                string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;

                string fullFileName = $"{projectDirectory}/KlientInserts.txt";

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
