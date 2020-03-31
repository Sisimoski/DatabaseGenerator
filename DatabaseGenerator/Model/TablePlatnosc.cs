using System;
using Oracle.ManagedDataAccess.Client;

namespace DatabaseGenerator.Model
{
    public class TablePlatnosc
    {
        public static string[] typplatnosciValues = { "Gotówka", "Karta Kredytowa", "Przelew" };

        public static string RandomDate = DateTime.Now.AddDays(Generator.random.Next(1, 100)).ToString("yyyyMMdd");

        public static int RandomizeNumerFakturyValue()
        {
            int numerFaktury = Generator.random.Next(1, 999999999);
            return numerFaktury;
        }

        public static int RandomizeKosztValue()
        {
            int koszt = Generator.random.Next(100, 500000);
            return koszt;
        }
    }
}
