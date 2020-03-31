using System;
using System.Text;
using Oracle.ManagedDataAccess.Client;

namespace DatabaseGenerator.Model
{
    public class TablePracownicy
    {
        public static string[] pracownicyImieValues = { "Adam", "Adrian", "Aleksander", "Andrzej", "Bartosz", "Damian", "Daniel", "Dawid", "Grzegorz", "Hubert", "Ignacy", "Jacek", "Jakub", "Janusz", "Kacper", "Kamil", "Kewin", "Krystian", "Krzysztof", "Kuba", "Łukasz", "Maciej", "Marcin", "Marek", "Mariusz", "Michał", "Mieszko", "Olaf", "Oskar", "Patryk", "Paweł", "Robert", "Radosław" };

        public static string[] pracownicyNazwiskoValues = { "Adamowicz", "Głód", "Jarzębski", "Jaruga", "Piwowar", "Kardas", "Stach", "Naruszewicz", "Kaim", "Gonciarz", "Sokół", "Grabski", "Mączyński", "Spałek", "Lipski", "Wyrzykowski", "Wydra", "Waliczek", "Banaszewski", "Rykaczewski", "Gomułka", "Żelazowski", "Magciarz", "Pawłowicz", "Wach", "Widomski", "Koc", "Nowok", "Wielgus", "Leszko", "Fil", "Buras", "Iwiński", "Szukała", "Popko", "Landowski", "Stepaniuk", "Pastuszak", "Pabich", "Katarzyński", "Zachariasz", "Gruszewski", "Krakuski", "Dulęba", "Kobylański", "Karczmarczyk", "Smolak", "Tylek", "Kaproń" };

        public static string RandomizeEmailValue()
        {
            StringBuilder emailBuilder = new StringBuilder();
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            var lengthOfEmailName = Generator.random.Next(4, 12);

            for (int i = 0; i < lengthOfEmailName; i++)
            {
                emailBuilder.Append(chars[Generator.random.Next(chars.Length)]);
            }

            string nameOfMail = emailBuilder.ToString();
            string domainOfMail = "@gmail.com";
            string fullMail = nameOfMail + domainOfMail;
            return fullMail;
        }

        public static string RandomizePhoneNumber()
        {
            StringBuilder phoneNumberBuilder = new StringBuilder();
            const string chars = "0123456789";
            var lengthOfPhoneNumber = 9;

            for (int i = 0; i < lengthOfPhoneNumber; i++)
            {
                phoneNumberBuilder.Append(chars[Generator.random.Next(chars.Length)]);
            }
            return phoneNumberBuilder.ToString();
        }
    }
}
