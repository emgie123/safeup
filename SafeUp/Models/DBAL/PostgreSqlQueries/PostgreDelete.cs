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
        private const string PATTERN = "delete from {0} where {1};";

        public string DeleteStatement(ITable table)
        {
            var where = new List<string>();

            foreach (var column in table.Row)
            {
                if (column.Value.IsWhere())
                {
                    where.Add(column.Value.GetColumnName() + SqlQueries.EqualOperator + GetSurroundedValue(column.Value.GetColumnValue()));
                }
            }
            var whereParameter = String.Join(SqlQueries.AndOperator, where);

            return string.Format(PATTERN, table.TableName, whereParameter);
        }
    }
}