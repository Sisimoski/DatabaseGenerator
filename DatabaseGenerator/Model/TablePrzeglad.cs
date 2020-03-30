using System;
using System.Text;

namespace DatabaseGenerator.Model
{
    public class TablePrzeglad
    {
        public TablePrzeglad()
        {
        }

        public static string DataPrzegladu = DateTime.Now.AddDays(Generator.random.Next(1, 100)).ToString("yyyyMMdd");

        public static int RandomizePrzebiegValue()
        {
            int przebieg = Generator.random.Next(1000, 500000);
            return przebieg;
        }

        public static int RandomizeIloscPaliwaValue()
        {
            int iloscPaliwa = Generator.random.Next(8, 1500);
            return iloscPaliwa;
        }
        public static string RandomizeCzyUszkodzonyValue()
        {
            StringBuilder iloscPaliwaBuilder = new StringBuilder();
            const string chars = "tn";
            var length = 1;

            for (int i = 0; i < length; i++)
            {
                iloscPaliwaBuilder.Append(chars[Generator.random.Next(chars.Length)]);
            }

            return iloscPaliwaBuilder.ToString();
        }
    }
}
