﻿using System;
using System.Linq;
using System.Text;
using SafeUp.Models.DBAL.Abstraction;
using SafeUp.Models.DBAL.Interfaces;
using SafeUp.Models.DBAL.Interfaces.SqlQueries;

namespace SafeUp.Models.DBAL.PostgreSqlQueries
{
    public class PostgreInsert : SqlQueries, IDbInsert
    {
        //string columnNames = string.Join(COLUMNS_DELIMITER, model.GetFields().Select(item => item.Key));

        //insert into users (id,name,costam) values ()


        public PostgreInsert()
        {
            _pattern = "insert into {0} ({1}) values ({2});";
        }
        public string InsertStatement(ITable table)
        {
            StringBuilder columnsValues = new StringBuilder();
            foreach (var column in table.Row.Values)
            {
                Type columnType = column.GetColumnValueType();
                if (base.Surroundings.ContainsKey(columnType))
                {
                    columnsValues.Append(base.Surroundings[columnType] + column.GetColumnValue().ToString() + base.Surroundings[columnType] + SqlQueries._columnDelimiter);                   
                }
                
            }
            columnsValues = columnsValues.Remove(columnsValues.Length - 1, 1);
            string columns = string.Join(_columnDelimiter, (table.Row.Select(column => column.Value.GetColumnName())));

            return string.Format(_pattern, table.TableName, columns, columnsValues);
        }
    }
}