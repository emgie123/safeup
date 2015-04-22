using System;
using System.Collections.Generic;
using System.Linq;
using SafeUp.Models.DBAL.Interfaces;

namespace SafeUp.Models.DBAL.Abstraction
{
    public class Column<T> : IColumn<T>
    {
        protected string ColumnName;
        protected T ColumnValue;


        public Column(string columnName, T columnValue)
        {
            this.ColumnName = ColumnName;
            this.ColumnValue = ColumnValue;
        }
        
        public T GetColumnValue()
        {
            return ColumnValue;
        }

        public string GetColumnName()
        {
           return ColumnName;
        }

        public void SetColumnValue(T columnValue)
        {
            this.ColumnValue = columnValue;
        }
    }
}