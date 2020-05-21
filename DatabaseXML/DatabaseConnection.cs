using System;
using System.Configuration;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
namespace DatabaseXML
{
    public class DatabaseConnection
    {
        readonly string connectionString;
        public static OracleConnection connection;

        public DatabaseConnection()
        {
            connectionString = ConfigurationManager.ConnectionStrings["SisimoskiSQLConnection"].ConnectionString;
            connection = new OracleConnection(connectionString);
        }

        public async Task ConnectToDatabaseAsync()
        {
            Console.WriteLine("Łączenie się z bazą danych...");
            try
            {
                await connection.OpenAsync();
                Console.WriteLine($"Połączono z bazą danych: {connection.DatabaseName}");
            }
            catch(OracleException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task DisconnectFromDatabase()
        {
            try
            {
                await connection.CloseAsync();
                await connection.DisposeAsync();
                Console.WriteLine("Rozłączono z bazą danych.");
            }
            catch (OracleException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
