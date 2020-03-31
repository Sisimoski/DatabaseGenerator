using System;
using System.Collections.Generic;
using System.Text;
using Oracle.ManagedDataAccess.Client;

namespace DatabaseGenerator.Model
{
    public class TableSamochod
    {
        public static List<string> ListOfVINs = new List<string>();
        public static string[] VINs = { };

        public static string RandomizeVIN()
        {
            StringBuilder vinBuilder = new StringBuilder();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var length = 17;

            for (int i = 0; i < length; i++)
            {
                vinBuilder.Append(chars[Generator.random.Next(chars.Length)]);
            }
            return vinBuilder.ToString();
        }

        public static string RandomizeTablicaRejestracyjna()
        {
            StringBuilder tablicaBuilder = new StringBuilder();
            const string numberChars = "0123456789";
            const string letterChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var lengthOfLetters = 3;
            var lengthOfNumbers = 4;

            for (int i = 0; i < lengthOfLetters; i++)
            {
                tablicaBuilder.Append(letterChars[Generator.random.Next(letterChars.Length)]);
            }
            for (int i = 0; i < lengthOfNumbers; i++)
            {
                tablicaBuilder.Append(numberChars[Generator.random.Next(numberChars.Length)]);
            }
            return tablicaBuilder.ToString();
        }
    }
}
