using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Npgsql;

namespace SafeUp.Models.DB
{
    public class PostgreClient : ClientBase
    {

        private NpgsqlConnection _connection;
        private const string ConnectionPattern = "Server={0};Port=5432;Database={1};User Id={2};Password={3};";
        private readonly string _connectionString;

        public PostgreClient()
        {
            _connectionString = string.Format(ConnectionPattern, "localhost","safeup","postgres","qwerty");
        }
        
        public PostgreClient(string name, string password, string dbAddress, string dbName) : base(name, password, dbAddress, dbName)
        {
            _connectionString = string.Format(ConnectionPattern, DbAddress, DbName, UserName, Password);
        }

        public override int SetData(string queryString)
        {
            using (_connection = new NpgsqlConnection(_connectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand(queryString, _connection);
                _connection.Open();
                return command.ExecuteNonQuery();
            }

        }

        public override DataSet GetData(string queryString)
        {
            using (_connection = new NpgsqlConnection(_connectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand(queryString, _connection);
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);

                var result = new DataSet();
                adapter.Fill(result);

                return result;
            }
        }
    }
}