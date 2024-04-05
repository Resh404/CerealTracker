using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;

namespace CerealAPI.Data
{
    public class AdoDatabaseConnector
    {
        // SingleTon
        private static readonly Lazy<AdoDatabaseConnector> LazyConnector
            = new Lazy<AdoDatabaseConnector>(() => new AdoDatabaseConnector());

        public static AdoDatabaseConnector Instance => LazyConnector.Value;

        private AdoDatabaseConnector() { }
        // Connect to MySQL server method
        private static async Task<MySqlConnection> ConnectToServerAsync()
        {
            try
            {
                // Read database configuration from JSON file
                var jsonConfig = await File.ReadAllTextAsync("databaseConfig.json");
                dynamic config = JObject.Parse(jsonConfig);

                // Extract connection parameters
                string host = config.database.host;
                string user = config.database.user;
                string password = config.database.password;
                int port = config.database.port;

                // Build connection string
                var connectionString = $"Server={host};Database=mysql;Uid={user};Pwd={password};Port={port}";

                // Connect to the server
                var connection = new MySqlConnection(connectionString);
                await connection.OpenAsync();

                return connection;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error connecting to the database: {e}");
                throw;
            }
        }

        // Connect to MySQL database method
        public static async Task<MySqlConnection> ConnectToDatabaseAsync(string databaseName = "cereal_database")
        {
            try
            {
                // Connect to the specified server
                var myDatabase = await ConnectToServerAsync();

                // Check if the database exists
                await using var cmd = myDatabase.CreateCommand();
                cmd.CommandText = $"SHOW DATABASES LIKE '{databaseName}'";
                var result = await cmd.ExecuteScalarAsync();

                if (result == null)
                {
                    // Create the database if it does not exist
                    cmd.CommandText = $"CREATE DATABASE {databaseName}";
                    await cmd.ExecuteNonQueryAsync();
                    Console.WriteLine($"Database '{databaseName}' created successfully.");
                }

                // Switch to the specific database
                cmd.CommandText = $"USE {databaseName}";
                await cmd.ExecuteNonQueryAsync();

                return myDatabase;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error connecting to the database: {e}");
                throw;
            }
        }
    }
}
