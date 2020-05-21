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
        /// <param name="export">Ścieżka do katalogu, do którego mają zostać wyeksportowane dane z bazy danych do pliku XML.</param>

        static async Task Main(string import, string export)
        {
            if (import != null)
            {

            }

            if (export != null)
            {
                var myConnection = new DatabaseConnection();
                await myConnection.ConnectToDatabaseAsync();

                var tables = new Table();
                await tables.FetchTablesAsync();

                var exportXML = new ExportDataFromDatabaseToXML();
                foreach (string table in tables.TableNamesList)
                {
                    await exportXML.ExportQueryResult(table, "S95287", table);
                }

                await myConnection.DisconnectFromDatabase();
            }
            else
            {
                Console.WriteLine("Użyj opcji --import lub --export, oraz podaj ścieżki do pliku.");
            }
        }
    }
}
