using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SafeUp.Models.DBAL.Abstraction;
using SafeUp.Models.Utilities;

namespace SafeUp.Models.DBAL.ConnectionDatas
{
    public class PostgreSqlConnectionData : DbConnectionData
    {
        public PostgreSqlConnectionData()
            : base(SqlClientsUtility.GetPostgreIDBConnectionData)
        {

        }

        public PostgreSqlConnectionData(string dbAddress,string dbName, string user, string password, string port="5432")
        {
            base.ConnectionData= new Dictionary<int, string>()
            {
                {1,dbAddress},
                {2,dbName},
                {3,user},
                {4,password},
                {5,port},
            };
        }
    }
}