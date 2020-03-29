using System;
using System.Text;
using Oracle.ManagedDataAccess.Client;

namespace DatabaseGenerator.Model
{
    public class TableKlient
    {
        // Initialize array of data
        public int[] klientIDValues = new int[3] { 6, 7, 8 };

        public string[] klientImieValues = { "Adam", "Adrian", "Aleksander", "Andrzej", "Bartosz", "Damian", "Daniel", "Dawid", "Grzegorz", "Hubert", "Ignacy", "Jacek", "Jakub", "Janusz", "Kacper", "Kamil", "Kewin", "Krystian", "Krzysztof", "Kuba", "Łukasz", "Maciej", "Marcin", "Marek", "Mariusz", "Michał", "Mieszko", "Olaf", "Oskar", "Patryk", "Paweł", "Robert", "Radosław" };

        public string[] klientNazwiskoValues = { "Adamowicz", "Głód", "Jarzębski", "Jaruga", "Piwowar", "Kardas", "Stach", "Naruszewicz", "Kaim", "Gonciarz", "Sokół", "Grabski", "Mączyński", "Spałek", "Lipski", "Wyrzykowski", "Wydra", "Waliczek", "Banaszewski", "Rykaczewski", "Gomułka", "Żelazowski", "Magciarz", "Pawłowicz", "Wach", "Widomski", "Koc", "Nowok", "Wielgus", "Leszko", "Fil", "Buras", "Iwiński", "Szukała", "Popko", "Landowski", "Stepaniuk", "Pastuszak", "Pabich", "Katarzyński", "Zachariasz", "Gruszewski", "Krakuski", "Dulęba", "Kobylański", "Karczmarczyk", "Smolak", "Tylek", "Kaproń" };

        public string[] klientUlicaValues = {"ul. Rycerska", "ul. Jaworowa", "ul. Nowa", "ul. Energetyków", "ul. Liliowa", "ul. Złota", "ul. Piłsudzkiego", "ul. Pogodna", "ul. Żwirowa", "ul. Puławska", "ul. Chrzowska", "ul. Kołobrzeska", "ul. Ciasna", "ul. Zachodnia", "ul. Wschodnia", "ul. Północna", "ul. Południowa", "ul. Wesoła", "ul. Główna", "ul. Rolnicza", "ul. Gliwicka", "ul.Portowa", "ul. Żołnierska" };

        public string[] klientMiastoValues = {"Warszawa", "Kraków", "Łódź", "Wrocław", "Poznań", "Gdańsk", "Szczecin", "Bydgoszcz", "Lublin", "Białystok", "Katowice", "Gdynia", "Częstochowa", "Radom", "Sosnowiec", "Toruń", "Kielce", "Rzeszów", "Gliwice", "Zabrze", "Olsztyn", "Bielsko-Biała", "Bytom", "Zielona Góra", "Rybnik", "Opole" };

        public string[] klientWojewodztwoValues = {"woj. dolnośląskie", "wol. kujawsko-pomorskie", "woj. lubelskie", "woj. lubuskie", "woj. łódzkie", "woj. małopolskie", "woj. mazowieckie", "woj. opolskie", "woj. podkarpackie", "woj. podlaskie", "woj. pomorskie", "woj. śląskie", "woj. świętokrzyskie", "woj. warmińsko-mazurskie", "woj. wielkopolskie", "woj. zachodniopomorskie" };

        //public String[] klientNumerTelefonuValues = {"123", "234", "345"};
        //public String[] klientKodPocztowyValues = {"KodQ", "KodW", "KodE" };
        //public String[] klientNumerPrawaJazdyValues = {"NumerPrawajazdy1", "NumerPrawajazdy2", "NumerPrawajazdy3" };
        //public String[] klientNumerKartyKredytowejValues = {"NumerKartyKredytowej1", "NumerKartyKredytowej2", "NumerKartyKredytowej3" };
        public string[] klientImieRanValues = new string[] { };
        public string[] klientNazwiskoRanValues = new string[] { };
        public string[] klientEmailRanValues = new string[] { };
        public string[] klientNumerTelefonuRanValues = new string[] { };
        public string[] klientUlicaRanValues = new string[] { };
        public string[] klientMiastoRanValues = new string[] { };
        public string[] klientWojewodztwoRanValues = new string[] { };
        public string[] klientKodPocztowyRanValues = new string[] { };
        public string[] klientNumerPrawaJazdyRanValues = new string[] { };
        public string[] klientNumerKartyKredytowejRanValues = new string[] { };

        Random rnd = new Random();

        public string RandomizeEmailValue()
        {
            StringBuilder emailBuilder = new StringBuilder();
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            var lengthOfEmailName = rnd.Next(4, 12);

            for (int i = 0; i < lengthOfEmailName; i++)
            {
                emailBuilder.Append(chars[rnd.Next(chars.Length)]);
            }

            string nameOfMail = emailBuilder.ToString();
            string domainOfMail = "@gmail.com";
            string fullMail = nameOfMail + domainOfMail;
            return fullMail;
        }

        public string RandomizePhoneNumber()
        {
            StringBuilder phoneNumberBuilder = new StringBuilder();
            const string chars = "0123456789";
            var lengthOfPhoneNumber = rnd.Next(9);

            for (int i=0; i < lengthOfPhoneNumber; i++)
            {
                phoneNumberBuilder.Append(chars[rnd.Next(chars.Length)]);
            }
            return phoneNumberBuilder.ToString();
        }

        //public string RandomizeUlica()
        //{
        //    StringBuilder ulicaBuilder = new StringBuilder();
        //    const string chars = "abcdefghijklmnopqrstuvwxyz";
        //    var length = rnd.Next(9);

        //    for (int i = 0; i < length; i++)
        //    {
        //        ulicaBuilder.Append(chars[rnd.Next(chars.Length)]);
        //    }

        //    string ulicaPrefix = "ul. ";
        //    string nameOfUlica = ulicaBuilder.ToString();
        //    string fullUlica = ulicaPrefix + nameOfUlica;
        //    return fullUlica;
        //}

        public string RandomizeKodPocztowy()
        {
            string RandomString(int size)
            {
                StringBuilder builder = new StringBuilder();
                const string chars = "0123456789";
                for (int i = 0; i < size; i++)
                {
                    builder.Append(chars[rnd.Next(chars.Length)]);
                }

                return builder.ToString();
            }
            string kodPocztowy1 = RandomString(2);
            string kodPocztowy2 = RandomString(3);

            string fullKodPocztowy = kodPocztowy1 + "-" + kodPocztowy2;

            return fullKodPocztowy;
        }

        public string RandomizeNumerPrawaJazdy()
        {
            string RandomString(int size)
            {
                StringBuilder builder = new StringBuilder();
                const string chars = "0123456789";
                for (int i = 0; i < size; i++)
                {
                    builder.Append(chars[rnd.Next(chars.Length)]);
                }

                return builder.ToString();
            }
            string numerPrawaJazdy1 = RandomString(5);
            string numerPrawaJazdy2 = RandomString(2);
            string numerPrawaJazdy3 = RandomString(4);

            string fullNumerPrawaJazdy = numerPrawaJazdy1 + "/" + numerPrawaJazdy2 + "/" + numerPrawaJazdy3;

            return fullNumerPrawaJazdy;
        }

        public string RandomizeNumerKartyKredytowej()
        {
            StringBuilder creditCardNumberBuilder = new StringBuilder();
            const string chars = "0123456789";
            var lengthOfPhoneNumber = rnd.Next(16);

            for (int i = 0; i < lengthOfPhoneNumber; i++)
            {
                creditCardNumberBuilder.Append(chars[rnd.Next(chars.Length)]);
            }
            return creditCardNumberBuilder.ToString();
        }


        public void AddToArraysWithSpecificBindArray()
        {
            for (int i=0; i < Generator.RowsToInsert; i++)
            {

            }
        }

    }
}
