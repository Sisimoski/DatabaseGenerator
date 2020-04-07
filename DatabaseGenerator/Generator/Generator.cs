using System;
using System.IO;
using DatabaseGenerator.Model;
using Oracle.ManagedDataAccess.Client;

namespace DatabaseGenerator
{
    public class Generator
    {
        public Generator()
        {
        }

        public static Random random = new Random();

        public void Generate()
        {
            bool run = true;

            while (run)
            {
                DatabaseTable.SelectAllAvailableTables();
                Console.Write("Do której tabeli chcesz wprowadzić dane?\n" +
                    "Aby wyjść z generatora wpisz \"X\".\n" +
                    "Wprowadź nazwę tabeli: ");
                string input = Console.ReadLine();
                switch (input.ToUpper())
                {
                    case "KLIENT":
                        GeneratorKlient.GenerateValueKlient();
                        break;
                    case "ODDZIAL":
                        GeneratorOddzial.GenerateOddzialData();
                        break;
                    case "OPINIA":
                        GeneratorOpinia.GenerateOpiniaValues();
                        break;
                    case "PLATNOSC":
                        GeneratorPlatnosc.GeneratePlatnoscValues();
                        break;
                    case "PRACOWNICY":
                        GeneratorPracownicy.GenerateValuePracownik();
                        break;
                    case "PRZEGLAD":
                        GeneratorPrzeglad.GeneratePrzegladValue();
                        break;
                    case "SAMOCHOD":
                        GeneratorSamochod.GenerateSamochodValues();
                        break;
                    case "SPECYFIKACJA_SAMOCHODU":
                        GeneratorSpecyfikacjaSamochodu.GenerateSpecyfikacjaSamochoduValues();
                        break;
                    case "WYNAJEM":
                        GeneratorWynajem.GenerateWynajemValues();
                        break;
                    case "ZNIZKA":
                        GeneratorZnizka.GenerateZnizkaValues();
                        break;
                    case "X":
                        run = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Złe wprowadzenie.");
                        break;
                }
            }
        }
    }
}
