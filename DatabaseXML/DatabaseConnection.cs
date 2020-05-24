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
        public static string OracleUserID;

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
                Console.WriteLine($"Połączono z bazą danych pomyślnie: {connection.DataSource}");
                Console.WriteLine($"Cześć, {await GetUserIDAsync()}!");
                
            }
            catch(OracleException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task DisconnectFromDatabaseAsync()
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

        public async Task<string> GetUserIDAsync()
        {
            OracleCommand command = new OracleCommand("", DatabaseConnection.connection);
            command.CommandText = $"select user from dual";
            command.CommandType = System.Data.CommandType.Text;
            OracleDataReader reader = command.ExecuteReader();
            await reader.ReadAsync();
            OracleUserID = reader.GetString(0);

            return OracleUserID;
        }
    }
}
