using System;
using System.Text;
using Oracle.ManagedDataAccess.Client;

namespace DatabaseGenerator.Model
{
    public class TableOddzial
    {
        public static string[] oddzialUlicaValues = { "ul. Rycerska", "ul. Jaworowa", "ul. Nowa", "ul. Energetyków", "ul. Liliowa", "ul. Złota", "ul. Piłsudzkiego", "ul. Pogodna", "ul. Żwirowa", "ul. Puławska", "ul. Chrzowska", "ul. Kołobrzeska", "ul. Ciasna", "ul. Zachodnia", "ul. Wschodnia", "ul. Północna", "ul. Południowa", "ul. Wesoła", "ul. Główna", "ul. Rolnicza", "ul. Gliwicka", "ul. Portowa", "ul. Żołnierska" };

        public static string[] oddzialMiastoValues = { "Warszawa", "Kraków", "Łódź", "Wrocław", "Poznań", "Gdańsk", "Szczecin", "Bydgoszcz", "Lublin", "Białystok", "Katowice", "Gdynia", "Częstochowa", "Radom", "Sosnowiec", "Toruń", "Kielce", "Rzeszów", "Gliwice", "Zabrze", "Olsztyn", "Bielsko-Biała", "Bytom", "Zielona Góra", "Rybnik", "Opole" };

        public static string[] oddzialWojewodztwoValues = { "woj. dolnośląskie", "wol. kujawsko-pomorskie", "woj. lubelskie", "woj. lubuskie", "woj. łódzkie", "woj. małopolskie", "woj. mazowieckie", "woj. opolskie", "woj. podkarpackie", "woj. podlaskie", "woj. pomorskie", "woj. śląskie", "woj. świętokrzyskie", "woj. warmińsko-mazurskie", "woj. wielkopolskie", "woj. zachodniopomorskie" };

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
    }
}
