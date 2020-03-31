using System;
using Oracle.ManagedDataAccess.Client;

namespace DatabaseGenerator
{
    public class DatabaseConnection
    {
        private string userID;
        private string password;
        private string dataSource;
        private string port;
        private string serviceName;

        public string connectionString;
        public static OracleConnection connection;

        public DatabaseConnection()
        {
        }

        public void ConnectToDatabase(bool defaultConnectionString) //do zmiany argument bool
        {
            switch (defaultConnectionString)
            {
                case false:
                    ConnectToDatabaseWithUserInput();
                    break;

                case true:
                    ConnectToDatabaseWithDefaultInput();
                    break;
            }
        }

        private void ConnectToDatabaseWithDefaultInput()
        {
            connectionString = Environment.GetEnvironmentVariable("SQLConnectionString");

            Console.WriteLine("Łączenie z bazą danych...");

            connection = new OracleConnection(connectionString);
            try
            {
                connection.Open();
                Console.WriteLine($"Połączono z bazą danych. Witaj {userID}!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ConnectToDatabaseWithUserInput()
        {
            Console.Write("Podaj UserID: ");
            userID = Console.ReadLine();

            Console.Write("Podaj hasło: ");
            password = Console.ReadLine();

            Console.Write($"Podaj źródło/adres: ");
            dataSource = Console.ReadLine();

            Console.Write($"Podaj port połączenia: ");
            port = Console.ReadLine();

            Console.Write($"Podaj SID: ");
            serviceName = Console.ReadLine();

            connectionString = $"User Id={userID};Password={password};Data Source={dataSource}:{port}/{serviceName};";

            Console.WriteLine("Łączenie z bazą danych...");

            connection = new OracleConnection(connectionString);

            try
            {
                connection.Open();
                Console.WriteLine($"Połączono z bazą danych. Witaj {userID}!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void DisconnectFromDatabase()
        {
            using (connection = new OracleConnection(connectionString))
            {
                using (OracleCommand cmd = connection.CreateCommand())
                {
                    Console.WriteLine("Trwa rozłączanie z bazą danych...");
                    try
                    {
                        connection.Dispose();

                        Console.WriteLine($"Rozłączono z bazą danych.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
