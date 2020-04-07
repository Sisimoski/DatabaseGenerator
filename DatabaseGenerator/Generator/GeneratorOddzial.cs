using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DatabaseGenerator.Model;
using Oracle.ManagedDataAccess.Client;

namespace DatabaseGenerator
{
    public class GeneratorOddzial
    {
        public GeneratorOddzial()
        {
        }

        public static int SelectLastID()
        {
            string command = $"SELECT NVL(MAX(id_oddzial), 0) FROM oddzial";

            OracleCommand cmd = new OracleCommand(command, DatabaseConnection.connection);
            int lastID = Convert.ToInt32(cmd.ExecuteScalar());
            return lastID;
        }

        public static void GenerateOddzialData()
        {
            int rowsInserted = 0;

            Console.Write("Wprowadź ilość wierszy do INSERT: ");
            int rowsToInsert = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < rowsToInsert; i++)
            {
                string ulicaLosowe = TableOddzial.oddzialUlicaValues[Generator.random.Next(0, TableOddzial.oddzialUlicaValues.Length)];
                string miastoLosowe = TableOddzial.oddzialMiastoValues[Generator.random.Next(0, TableOddzial.oddzialMiastoValues.Length)];
                string wojewodztwoLosowe = TableOddzial.oddzialWojewodztwoValues[Generator.random.Next(0, TableOddzial.oddzialWojewodztwoValues.Length)];
                string kodpocztowyLosowe = TableOddzial.RandomizeKodPocztowy();

                string command = $"INSERT INTO oddzial(adres, miasto, wojewodztwo, kod_pocztowy) VALUES('{ulicaLosowe}', '{miastoLosowe}', '{wojewodztwoLosowe}', '{kodpocztowyLosowe}')";
                string commandToWriteToFile = $"INSERT INTO oddzial(adres, miasto, wojewodztwo, kod_pocztowy) VALUES('{ulicaLosowe}', '{miastoLosowe}', '{wojewodztwoLosowe}', '{kodpocztowyLosowe}')" + "\n";

                // This will get the current WORKING directory (i.e. \bin\Debug)
                string workingDirectory = Environment.CurrentDirectory;
                // or: Directory.GetCurrentDirectory() gives the same result

                // This will get the current PROJECT directory
                string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;

                string fullFileName = $"{projectDirectory}/OddzialInserts.txt";

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
