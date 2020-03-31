using System;
using Oracle.ManagedDataAccess.Client;

namespace DatabaseGenerator.Model
{
    public class TableWynajem
    {
        public TableWynajem()
        {
        }
        public static string DataWynajmu = DateTime.Now.ToString("yyyyMMdd");
        public static string DataZwrotu = DateTime.Now.AddDays(Generator.random.Next(5, 60)).ToString("yyyyMMdd");
    }
}
