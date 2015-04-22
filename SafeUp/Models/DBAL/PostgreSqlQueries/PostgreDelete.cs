using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SafeUp.Models.DBAL.Abstraction;
using SafeUp.Models.DBAL.Interfaces;
using SafeUp.Models.DBAL.Interfaces.SqlQueries;

namespace SafeUp.Models.DBAL.PostgreSqlQueries
{
    public class PostgreDelete : SqlQueries,IDbDelete
    {
        public string DeleteStatement(ITable table)
        {
            throw new NotImplementedException();
        }
    }
}