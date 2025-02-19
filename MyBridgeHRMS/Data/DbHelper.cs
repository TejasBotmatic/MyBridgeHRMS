using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

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

        // 🔹 COMMON METHOD TO EXECUTE QUERY (SELECT) ASYNCHRONOUSLY
        public async Task<List<Dictionary<string, object>>> ExecuteQueryAsync(string storedProcedure, Dictionary<string, object> parameters = null)
        {
            var resultList = new List<Dictionary<string, object>>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                using (var command = new MySqlCommand(storedProcedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    AddParameters(command, parameters);

                    await connection.OpenAsync(); // Async connection opening
                    using (var reader = await command.ExecuteReaderAsync()) // Async reader execution
                    {
                        while (await reader.ReadAsync()) // Asynchronously read rows
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

        // 🔹 COMMON METHOD TO EXECUTE NON-QUERY (INSERT, UPDATE, DELETE) ASYNCHRONOUSLY
        public async Task<int> ExecuteNonQueryAsync(string storedProcedure, Dictionary<string, object> parameters)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                using (var command = new MySqlCommand(storedProcedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    AddParameters(command, parameters);

                    await connection.OpenAsync(); // Async connection opening
                    return await command.ExecuteNonQueryAsync(); // Async execution
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
