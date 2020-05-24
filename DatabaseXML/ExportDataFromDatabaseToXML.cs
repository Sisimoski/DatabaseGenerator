using System;
using System.IO;
using System.Xml;
using Oracle.ManagedDataAccess.Client;

namespace DatabaseXML
{
    public class ExportDataFromDatabaseToXML
    {
        public void ExportQueryResult(string table, string rootTag, string rowTag)
        {
            try
            {
                OracleCommand command = new OracleCommand("", DatabaseConnection.connection);
                command.XmlCommandType = OracleXmlCommandType.Query;
                command.CommandText = $"SELECT * FROM {table.ToUpper()}";
                command.BindByName = true;
                command.XmlQueryProperties.MaxRows = -1;
                command.XmlQueryProperties.RootTag = rootTag.ToUpper();
                command.XmlQueryProperties.RowTag = rowTag.ToUpper();

                XmlReader xmlReader = command.ExecuteXmlReader();
                XmlDocument xmlDocument = new XmlDocument();

                xmlDocument.PreserveWhitespace = true;
                xmlDocument.Load(xmlReader);

                // This will get the current WORKING directory (i.e. \bin\Debug)
                string workingDirectory = Environment.CurrentDirectory;
                string xmlsDirectory = @$"{workingDirectory}/Export";

                if (!Directory.Exists(xmlsDirectory))
                {
                    Directory.CreateDirectory(xmlsDirectory);
                }

                FileStream file = File.Create($"{workingDirectory}/Export/{table.ToUpper()}.xml");
                xmlDocument.Save(file);
                file.Close();

                Console.WriteLine(xmlDocument.OuterXml);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
