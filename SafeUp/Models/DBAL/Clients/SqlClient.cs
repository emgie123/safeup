using System.Collections.Generic;
using System.Data;
using SafeUp.Models.DBAL.Interfaces;

namespace SafeUp.Models.DBAL.Clients
{
    public abstract class SqlClient : IClient
    {
        protected string ConnectionPattern;
        protected string ConnectionString;

        protected Dictionary<int, string> ConnectionData { get; private set; }

        protected SqlClient(IDbConnectionData dbConnectionData)
        {
            ConnectionData = dbConnectionData.ConnectionData;
        }

        public abstract int SaveData(string query);
        public abstract DataSet GetData();

     

    }
}