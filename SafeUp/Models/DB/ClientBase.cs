using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SafeUp.Models.DB
{
    public abstract class ClientBase : IDbClient
    {
        protected string UserName { get; private set; }
        protected string Password { get; private set; }
        protected string DbAddress { get; private set; }
        protected string DbName { get; private set; }

        protected ClientBase(string userName, string password, string dbAddress, string dbName)
        {
            UserName = userName;
            Password = password;
            DbAddress = dbAddress;
            DbName = dbName;
        }

        public abstract int SetData(string queryString);


        public abstract DataSet GetData(string queryString);

    }
}