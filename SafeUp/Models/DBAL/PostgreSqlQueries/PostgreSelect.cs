using System;
using System.Collections.Generic;
using System.Linq;
using SafeUp.Models.DBAL.Abstraction;
using SafeUp.Models.DBAL.Interfaces;
using SafeUp.Models.DBAL.Interfaces.SqlQueries;

namespace SafeUp.Models.DBAL.PostgreSqlQueries
{
    public class PostgreSelect : SqlQueries, IDbSelect
    {
        private const string SELECT_PATTERN = "SELECT {0} FROM {1}";
        private const string WHERE_PATTERN = "SELECT {0} FROM {1} WHERE {2}";
        private const string WHERE = "{0} {1} {2}";
        private const string AND = " AND ";
        private bool where;

        public string SelectStatement(ITable table)
        {
            string columnsNames = string.Join(SqlQueries._columnDelimiter, table.Row.Select(column => column.Value.GetColumnName()));

            List<string> whereList = new List<string>();
            foreach (var column in table.Row)
            {
                if (column.Value.IsWhere())
                {
                    whereList.Add(string.Format(WHERE, column.Value.GetColumnName(), GetClausuleSign(column.Value.GetSelectClause()), GetSurroundedValue(column.Value.GetColumnValue())));
                    where = true;
                }
            }
            var whereResult = string.Join(AND, whereList);
            if (where)
            {
                return string.Format(WHERE_PATTERN, columnsNames, table.TableName, whereResult);
            }
            return string.Format(SELECT_PATTERN, columnsNames, table.TableName);
        }
    }
}