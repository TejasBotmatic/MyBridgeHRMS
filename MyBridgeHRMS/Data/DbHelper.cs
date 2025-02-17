using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;


namespace MyBridgeHRMS.Data
{
    public class DbHelper
    {
        private readonly string _connectionString;
        public DbHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        // 🔹 Example method to ensure it works
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }
        // 🔹 COMMON METHOD TO EXECUTE QUERY (SELECT)
        public List<Dictionary<string, object>> ExecuteQuery(string storedProcedure, Dictionary<string, object> parameters = null)
        {
            var resultList = new List<Dictionary<string, object>>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                using (var command = new MySqlCommand(storedProcedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    AddParameters(command, parameters);

                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var row = new Dictionary<string, object>();

                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row[reader.GetName(i)] = reader.IsDBNull(i) ? null : reader.GetValue(i);
                            }

                            resultList.Add(row);
                        }
                    }
                }
            }
            return resultList;
        }


        // 🔹 COMMON METHOD TO EXECUTE NON-QUERY (INSERT, UPDATE, DELETE)
        public int ExecuteNonQuery(string storedProcedure, Dictionary<string, object> parameters)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                using (var command = new MySqlCommand(storedProcedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    AddParameters(command, parameters);

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        // 🔹 HELPER METHOD TO ADD PARAMETERS
        private void AddParameters(MySqlCommand command, Dictionary<string, object> parameters)
        {
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value);
                }
            }
        }
    }
}
