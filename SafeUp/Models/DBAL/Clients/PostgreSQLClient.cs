using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Npgsql;
using SafeUp.Models.DBAL.Enums;
using SafeUp.Models.DBAL.Interfaces;
using SafeUp.Models.Utilities;

namespace SafeUp.Models.DBAL.Clients
{
    public class PostgreSQLClient : SqlClient
    {

        public PostgreSQLClient(IDbConnectionData dbConnectionData) : base (dbConnectionData)
        {
            ConnectionPattern = "Server={0};Port={1};Database={2};User Id={3};Password={4};";

            ConnectionString = string.Format(
            ConnectionPattern, 
            ConnectionData[(int)SqlDataConnectionKeys.Server],
            ConnectionData[(int)SqlDataConnectionKeys.Port],
            ConnectionData[(int)SqlDataConnectionKeys.Database],
            ConnectionData[(int)SqlDataConnectionKeys.UserId],
            ConnectionData[(int)SqlDataConnectionKeys.Password]
            );
        }


        public override int SaveData(string query)
        {
            IDbConnectionData 
        }

        public override DataSet GetData()
        {
            throw new NotImplementedException();
        }
    }
}