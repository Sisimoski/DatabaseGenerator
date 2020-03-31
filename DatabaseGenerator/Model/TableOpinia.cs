using System;
using System.Text;
using Oracle.ManagedDataAccess.Client;

namespace DatabaseGenerator.Model
{
    public class TableOpinia
    {
        public static string[] opiniaKomentarzValues = { "Super!", "Super", "Bardzo fajne.", "Bardzo fajnie!", "Świetnie", "Rewelacyjnie", "Doskonale", "Fantastycznie", "Średnio", "Może być", "Słabo", "Nie podoba mi się", "Podoba mi się", "Pozdrawiam" };

        public static int RandomizeRateValue()
        {
            int rate = Generator.random.Next(1, 7);
            return rate;
        }

        
    }
}
