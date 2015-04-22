using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SafeUp.Models.DBAL.Interfaces;

namespace SafeUp.Models.DBAL.Abstraction
{
    public abstract class DbConnectionData : IDbConnectionData
    {
        public Dictionary<int, string> ConnectionData { get; protected set; }


        protected DbConnectionData()
        {
          
        }
        protected DbConnectionData(Dictionary<int, string> connectionData) 
        {
            ConnectionData = connectionData;
        }

       
    }
}