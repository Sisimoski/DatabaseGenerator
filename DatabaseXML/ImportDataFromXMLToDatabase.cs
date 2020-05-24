using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Oracle.ManagedDataAccess.Client;
namespace DatabaseXML
{
    public class ImportDataFromXMLToDatabase
    {
        private int rowsInserted;
        private string filePath;
        private string table;

        List<string> ColumnsList = new List<string>();

        XmlDocument xmlDocument = new XmlDocument();
        XmlDocument xmlToDisplay = new XmlDocument();

        public void ImportQueryResult(string filePath, string table)
        {
            this.filePath = filePath;
            this.table = table;

            OracleCommand command = new OracleCommand("", DatabaseConnection.connection);
            command.XmlCommandType = OracleXmlCommandType.Insert;

            LoadXMLFile();
            PrintXMLFileFormatted();

            try
            {
                command.CommandText = xmlDocument.OuterXml;

                AddNodesToList();
                PrintColumnsList();

                List<string> KeyColumnsList = new List<string>();
                KeyColumnsList.Add(ColumnsList[0]);

                //Set the XML save properties.
                command.XmlSaveProperties.Table = table;
                command.XmlSaveProperties.RowTag = table;
                command.XmlSaveProperties.KeyColumnsList = KeyColumnsList.ToArray();
                command.XmlSaveProperties.UpdateColumnsList = ColumnsList.ToArray();

                rowsInserted = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Błąd. Prawdopodobnie błędny format pliku XML.\n" + ex.Message);
            }

            Console.WriteLine("Liczba wierszy wstawionych pomyślnie: {0}", rowsInserted);
        }

        public void LoadXMLFile()
        {
            xmlToDisplay.PreserveWhitespace = true;

            try
            {
                xmlDocument.Load(filePath);
                xmlToDisplay.Load(filePath);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Błąd. Nie udało się wczytać pliku. Sprawdź, czy wprowadziłeś odpowiedni plik. W przeciwnym razie plik może być uszkodzony. Szczegóły:\n" + ex.Message);
            }
        }

        public void PrintXMLFileFormatted()
        {
            Console.WriteLine($"\nZawartość pliku XML wczytanego z katalogu {filePath}:");
            Console.WriteLine("---------------");
            Console.WriteLine(xmlToDisplay.OuterXml);
            Console.WriteLine("---------------");
        }

        public void AddNodesToList()
        {
            XmlNodeList nodeList = xmlDocument.SelectNodes($"{DatabaseConnection.OracleUserID}/{table}");

            foreach (XmlNode node in nodeList)
            {
                foreach (XmlNode childNode in node.ChildNodes)
                {
                    if (!ColumnsList.Contains(childNode.Name))
                    {
                        ColumnsList.Add(childNode.Name);
                    }
                }
            }
        }

        public void PrintColumnsList()
        {
            int index = 0;

            if (ColumnsList.Count > 0)
            {
                Console.WriteLine($"Lista kolumn w tabeli {table}:");
                
                foreach (var item in ColumnsList)
                {
                    index++;
                    Console.WriteLine($"\t{index}. {item}");
                }
                Console.WriteLine();
                
            }
            else
            {
                throw new Exception("Błąd. Nie udało się wczytać listy kolumn z pliku XML.");
            }
        }
    }
}
