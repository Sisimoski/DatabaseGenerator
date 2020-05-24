using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace DatabaseXML
{
    public class TableNames
    {
        public List<string> TableNamesList = new List<string>() { };

        public TableNames()
        {
            TableNamesList.Clear();
        }

        public void FetchTables()
        {
            try
            {
                OracleCommand command = new OracleCommand("", DatabaseConnection.connection);

                command.CommandText = @"SELECT table_name FROM user_tables";
                command.BindByName = true;

                OracleDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    TableNamesList.Add(reader.GetString(0));
                }

                reader.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
