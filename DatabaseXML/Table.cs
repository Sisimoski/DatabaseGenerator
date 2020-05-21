using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace DatabaseXML
{
    public class Table
    {
        public List<string> TableNamesList = new List<string>() { };

        public async Task FetchTablesAsync()
        {
            try
            {
                OracleCommand command = new OracleCommand("", DatabaseConnection.connection);

                command.CommandText = @"SELECT table_name FROM user_tables";
                command.BindByName = true;

                OracleDataReader reader = await Task.Run(() => command.ExecuteReader());

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
