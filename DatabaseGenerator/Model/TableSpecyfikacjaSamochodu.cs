using System;
using Oracle.ManagedDataAccess.Client;

namespace DatabaseGenerator.Model
{
    public class TableSpecyfikacjaSamochodu
    {
        public TableSpecyfikacjaSamochodu()
        {
        }

        public static string[] specyfikacjaSamochoduProducentValues = { "Peugeot", "Citroen", "Suzuki", "Fiat", "Chrysler", "Honda", "Ford", "Hyundai", "Kia", "Renault", "Nissan", "Toyota", "BMW", "Audi", "Mercedes-Benz", "Volkswagen", "Porsche" };

        public static string[] specyfikacjaSamochoduModelValues = { "2008", "3008", "5008", "208", "308", "508", "Clio", "Megane", "Mondeo", "Fiesta", "Focus", "i20", "i30", "Juke", "Micra", "Seria 3", "Seria 5", "Seria 4", "Seria 8", "A3", "A4", "A5", "A6", "Carerra S", "Golf", "Passat", "Polo" };

        public static string[] specyfikacjaSamochoduKolorValues = { "Czarny", "Biały", "Czerwony", "Pomarańczowy", "Żółty", "Zielony", "Fioletowy", "Niebieski", "Brązowy", "Granatowy", "Szary" };

        public static int RandomizeSpecyfikacjaSamochoduDateValues()
        {
            DateTime start = new DateTime(1997, 1, 1);
            int range = (DateTime.Today - start).Days;
            string yearManufacture = start.AddDays(Generator.random.Next(range)).ToString("yyyy");
            return Convert.ToInt32(yearManufacture);
        }
    }
}
