using System;
using SafeUp.Models.DBAL.Abstraction;
using SafeUp.Models.DBAL.Interfaces;
using SafeUp.Models.DBAL.Interfaces.SqlQueries;

namespace SafeUp.Models.DBAL.PostgreSqlQueries
{
    public class PostgreSelect : SqlQueries, IDbSelect
    {
        public string SelectStatement(ITable table)
        {
            throw new NotImplementedException();
        }
    }
}