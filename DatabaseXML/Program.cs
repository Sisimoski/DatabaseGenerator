using System;
using System.Threading.Tasks;

namespace DatabaseXML
{
    class Program
    {
        /// <summary>
        /// Program umożliwia zaimportowanie lub wyeksportowanie danych z/do pliku XML do/z bazy danych. 
        /// </summary>
        /// <param name="import">Ścieżka do pliku XML, z którego mają dane mają zostać zaimportowane do bazy danych </param>
        /// <param name="export">Opcja która umożliwia wyeksportowanie danych tabel w plikach XML w folderze /Export.</param>

        static async Task Main(string import, bool export)
        {
            if (import != null)
            {
                var myConnection = new DatabaseConnection();
                await myConnection.ConnectToDatabaseAsync();

                Console.WriteLine("Wybierz tabelę do której chcesz zaimportować dane.");

                TableNames tables = new TableNames();
                tables.FetchTables();

                foreach (string table in tables.TableNamesList)
                {
                    Console.WriteLine("\t" + table);
                }

                Console.Write("Tabela: ");
                string tableInput = Console.ReadLine();

                ImportDataFromXMLToDatabase importXML = new ImportDataFromXMLToDatabase();
                importXML.ImportQueryResult(import, tableInput.ToUpper());

                await myConnection.DisconnectFromDatabaseAsync();
            }

            if (export == true)
            {
                var myConnection = new DatabaseConnection();
                await myConnection.ConnectToDatabaseAsync();

                var tables = new TableNames();
                tables.FetchTables();

                var exportXML = new ExportDataFromDatabaseToXML();

                try
                {
                    foreach (string table in tables.TableNamesList)
                    {
                        exportXML.ExportQueryResult(table, DatabaseConnection.OracleUserID, table);
                    }
                    Console.WriteLine($"Wyeksportowano dane pomyślnie do folderu: {Environment.CurrentDirectory}/Export");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

                await myConnection.DisconnectFromDatabaseAsync();
            }
            else if (import == null && export == false)
            {
                Console.WriteLine("Użyj opcji --import lub --export.");
            }
        }
    }
}
