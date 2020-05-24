using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Oracle.ManagedDataAccess.Client;
namespace DatabaseXML
{
    public class ImportDataFromXMLToDatabase
    {
        List<string> ColumnsList = new List<string>();
        private int rows;

        public void ImportQueryResult(string filePath, string table)
        {
            OracleCommand command = new OracleCommand("", DatabaseConnection.connection);
            command.XmlCommandType = OracleXmlCommandType.Insert;

            XmlDocument xmlDocument = new XmlDocument();

            try
            {
                xmlDocument.Load(filePath);
            }
            catch (FileLoadException ex)
            {
                Console.WriteLine(ex);
            }


            try
            {
                Console.WriteLine(xmlDocument.OuterXml);
                command.CommandText = xmlDocument.OuterXml;

                XmlNodeList nodeList = xmlDocument.SelectNodes($"{DatabaseConnection.OracleUserID}/{table}");

                foreach (XmlNode node in nodeList)
                {
                    foreach (XmlNode childNode in node.ChildNodes)
                    {
                        if (!ColumnsList.Contains(childNode.Name))
                        {
                            Console.WriteLine(childNode.Name);
                            ColumnsList.Add(childNode.Name);
                        }
                    }
                }

                List<string> KeyColumnsList = new List<string>();
                KeyColumnsList.Add(ColumnsList[0]);

                //Set the XML save properties.
                command.XmlSaveProperties.Table = table;
                command.XmlSaveProperties.RowTag = table;
                command.XmlSaveProperties.KeyColumnsList = KeyColumnsList.ToArray();
                command.XmlSaveProperties.UpdateColumnsList = ColumnsList.ToArray();

                rows = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.WriteLine("Liczba wierszy wstawionych pomyślnie: {0}", rows);
        }
    }
}
