using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SafeUp.Models.DBAL.Abstraction;
using SafeUp.Models.DBAL.Interfaces;
using SafeUp.Models.DBAL.Interfaces.SqlQueries;

namespace SafeUp.Models.DBAL.PostgreSqlQueries
{
    public class PostgreUpdate : SqlQueries, IDbUpdate
    {
        private const string Pattern = "UPDATE {0} SET {1} WHERE {2};";
        private const string AssignmentPattern = "{0} = {1}";
        
        //private const string Comma = ", ";  SqlQueries._columnDelimiter
        private const int MinStatementLength = 2;

        public string UpdateStatement(ITable table)
        {
            var where = GetWhereStatement(table);
            if (where.Length < MinStatementLength)
            {
                return string.Empty;
            }
            return string.Format(Pattern, table.TableName, GetSetStatement(table), where);

        }

        private string GetSetStatement(ITable table)
        {
            var list = new List<string>();
            foreach (var column in table.Row)
            {
                list.Add(string.Format(AssignmentPattern, column.Value.GetColumnName(), GetSurroundedValue(column.Value.GetColumnValue())));
            }
            return string.Join(SqlQueries.ColumnDelimiter, list);
        }

        private string GetWhereStatement(ITable table)
        {
            var list = new List<string>();
            foreach (var column in table.Row)
            {
                if (column.Value.IsWhere())
                {
                    list.Add(string.Format(AssignmentPattern, column.Value.GetColumnName(), GetSurroundedValue(column.Value.GetColumnValue())));
                }
            }
            return string.Join(SqlQueries.AndOperator, list);
        }
    }
}