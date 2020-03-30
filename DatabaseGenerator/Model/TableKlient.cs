using System.Text;

namespace DatabaseGenerator.Model
{
    public class TableKlient
    {
        // Initialize array of data

        public static string[] klientImieValues = { "Adam", "Adrian", "Aleksander", "Andrzej", "Bartosz", "Damian", "Daniel", "Dawid", "Grzegorz", "Hubert", "Ignacy", "Jacek", "Jakub", "Janusz", "Kacper", "Kamil", "Kewin", "Krystian", "Krzysztof", "Kuba", "Łukasz", "Maciej", "Marcin", "Marek", "Mariusz", "Michał", "Mieszko", "Olaf", "Oskar", "Patryk", "Paweł", "Robert", "Radosław" };

        public static string[] klientNazwiskoValues = { "Adamowicz", "Głód", "Jarzębski", "Jaruga", "Piwowar", "Kardas", "Stach", "Naruszewicz", "Kaim", "Gonciarz", "Sokół", "Grabski", "Mączyński", "Spałek", "Lipski", "Wyrzykowski", "Wydra", "Waliczek", "Banaszewski", "Rykaczewski", "Gomułka", "Żelazowski", "Magciarz", "Pawłowicz", "Wach", "Widomski", "Koc", "Nowok", "Wielgus", "Leszko", "Fil", "Buras", "Iwiński", "Szukała", "Popko", "Landowski", "Stepaniuk", "Pastuszak", "Pabich", "Katarzyński", "Zachariasz", "Gruszewski", "Krakuski", "Dulęba", "Kobylański", "Karczmarczyk", "Smolak", "Tylek", "Kaproń" };

        public static string[] oddzialUlicaValues = {"ul. Rycerska", "ul. Jaworowa", "ul. Nowa", "ul. Energetyków", "ul. Liliowa", "ul. Złota", "ul. Piłsudzkiego", "ul. Pogodna", "ul. Żwirowa", "ul. Puławska", "ul. Chrzowska", "ul. Kołobrzeska", "ul. Ciasna", "ul. Zachodnia", "ul. Wschodnia", "ul. Północna", "ul. Południowa", "ul. Wesoła", "ul. Główna", "ul. Rolnicza", "ul. Gliwicka", "ul. Portowa", "ul. Żołnierska" };

        public static string[] oddzialMiastoValues = {"Warszawa", "Kraków", "Łódź", "Wrocław", "Poznań", "Gdańsk", "Szczecin", "Bydgoszcz", "Lublin", "Białystok", "Katowice", "Gdynia", "Częstochowa", "Radom", "Sosnowiec", "Toruń", "Kielce", "Rzeszów", "Gliwice", "Zabrze", "Olsztyn", "Bielsko-Biała", "Bytom", "Zielona Góra", "Rybnik", "Opole" };

        public static string[] oddzialWojewodztwoValues = {"woj. dolnośląskie", "wol. kujawsko-pomorskie", "woj. lubelskie", "woj. lubuskie", "woj. łódzkie", "woj. małopolskie", "woj. mazowieckie", "woj. opolskie", "woj. podkarpackie", "woj. podlaskie", "woj. pomorskie", "woj. śląskie", "woj. świętokrzyskie", "woj. warmińsko-mazurskie", "woj. wielkopolskie", "woj. zachodniopomorskie" };


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

            for (int i=0; i < lengthOfPhoneNumber; i++)
            {
                phoneNumberBuilder.Append(chars[Generator.random.Next(chars.Length)]);
            }
            return phoneNumberBuilder.ToString();
        }

        public static string RandomizeKodPocztowy()
        {
            string RandomString(int size)
            {
                StringBuilder builder = new StringBuilder();
                const string chars = "0123456789";
                for (int i = 0; i < size; i++)
                {
                    builder.Append(chars[Generator.random.Next(chars.Length)]);
                }

                return builder.ToString();
            }
            string kodPocztowy1 = RandomString(2);
            string kodPocztowy2 = RandomString(3);

            string fullKodPocztowy = kodPocztowy1 + "-" + kodPocztowy2;

            return fullKodPocztowy;
        }

        public static string RandomizeNumerPrawaJazdy()
        {
            string RandomString(int size)
            {
                StringBuilder builder = new StringBuilder();
                const string chars = "0123456789";
                for (int i = 0; i < size; i++)
                {
                    builder.Append(chars[Generator.random.Next(chars.Length)]);
                }

                return builder.ToString();
            }
            string numerPrawaJazdy1 = RandomString(5);
            string numerPrawaJazdy2 = RandomString(2);
            string numerPrawaJazdy3 = RandomString(4);

            string fullNumerPrawaJazdy = numerPrawaJazdy1 + "/" + numerPrawaJazdy2 + "/" + numerPrawaJazdy3;

            return fullNumerPrawaJazdy;
        }

        public static string RandomizeNumerKartyKredytowej()
        {
            StringBuilder creditCardNumberBuilder = new StringBuilder();
            const string chars = "0123456789";
            var lengthOfPhoneNumber = 16;

            for (int i = 0; i < lengthOfPhoneNumber; i++)
            {
                creditCardNumberBuilder.Append(chars[Generator.random.Next(chars.Length)]);
            }
            return creditCardNumberBuilder.ToString();
        }

    }
}
