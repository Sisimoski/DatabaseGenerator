using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DatabaseGenerator.Model;
using Oracle.ManagedDataAccess.Client;

namespace DatabaseGenerator
{
    public class GeneratorPlatnosc
    {
        public GeneratorPlatnosc()
        {
        }

        public static int SelectLastID()
        {
            string command = $"SELECT NVL(MAX(id_platnosc), 0) FROM platnosc";

            OracleCommand cmd = new OracleCommand(command, DatabaseConnection.connection);
            int lastID = Convert.ToInt32(cmd.ExecuteScalar());
            return lastID;
        }

        public static void GeneratePlatnoscValues()
        {
            int rowsInserted = 0;

            Console.Write("Wprowadź ilość wierszy do INSERT: ");
            int rowsToInsert = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < rowsToInsert; i++)
            {
                bool includeDiscount = false;
                int idznizkaLosowe = 0;
                if (GeneratorZnizka.SelectLastID() > 0)
                {
                    idznizkaLosowe = Generator.random.Next(1, GeneratorZnizka.SelectLastID());
                    includeDiscount = true;
                }
                int numerFakturyLosowe = TablePlatnosc.RandomizeNumerFakturyValue();
                int kosztLosowe = TablePlatnosc.RandomizeKosztValue();
                string dataLosowe = TablePlatnosc.RandomDate;
                string typplatnosciLosowe = TablePlatnosc.typplatnosciValues[Generator.random.Next(0, TablePlatnosc.typplatnosciValues.Length)];

                string command = $"INSERT INTO platnosc(numer_faktury, data_platnosci, typ_platnosci, koszt) VALUES({numerFakturyLosowe}, '{dataLosowe}', '{typplatnosciLosowe}', {kosztLosowe})";
                string commandToWriteToFile = $"INSERT INTO platnosc(numer_faktury, data_platnosci, typ_platnosci, koszt) VALUES({numerFakturyLosowe}, '{dataLosowe}', '{typplatnosciLosowe}', {kosztLosowe})" + "\n";

                string commandWithDiscount = $"INSERT INTO platnosc(id_znizka, numer_faktury, data_platnosci, typ_platnosci, koszt) VALUES({idznizkaLosowe}, {numerFakturyLosowe}, '{dataLosowe}', '{typplatnosciLosowe}', {kosztLosowe})";
                string commandWithDiscountToWriteToFile = $"INSERT INTO platnosc(id_znizka, numer_faktury, data_platnosci, typ_platnosci, koszt) VALUES({idznizkaLosowe}, {numerFakturyLosowe}, '{dataLosowe}', '{typplatnosciLosowe}', {kosztLosowe})" + "\n";

                // This will get the current WORKING directory (i.e. \bin\Debug)
                string workingDirectory = Environment.CurrentDirectory;
                // or: Directory.GetCurrentDirectory() gives the same result

                // This will get the current PROJECT directory
                string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;

                string fullFileName = $"{projectDirectory}/PlatnoscInserts.txt";

                switch (includeDiscount)
                {
                    case true:
                        OracleCommand cmddiscount = new OracleCommand(commandWithDiscount, DatabaseConnection.connection);
                        try
                        {
                            cmddiscount.ExecuteNonQuery();
                            File.AppendAllText(fullFileName, commandWithDiscountToWriteToFile);
                            rowsInserted++;

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Błąd: " + e.Message);
                        }
                        finally
                        {
                            cmddiscount.Dispose();
                        }
                        break;
                    case false:
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
                        break;
                }
            }
            Console.WriteLine("[{0}] Wierszy Wstawiono", rowsInserted);
        }
    }
}
