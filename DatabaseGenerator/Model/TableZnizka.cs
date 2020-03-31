using System;
using System.Text;
using Oracle.ManagedDataAccess.Client;

namespace DatabaseGenerator.Model
{
    public class TableZnizka
    {
        public TableZnizka()
        {
        }

        public static string[] Opis = { "Promocja", "Żniżka", "Kupon rabatowy", "Brak żniżki" };

        public static string RandomizeKodZnizkowy()
        {
            StringBuilder kodBuilder = new StringBuilder();
            const string chars = "0123456789";
            var lengthOfPhoneNumber = 10;

            for (int i = 0; i < lengthOfPhoneNumber; i++)
            {
                kodBuilder.Append(chars[Generator.random.Next(chars.Length)]);
            }
            return kodBuilder.ToString();
        }
    }
}
