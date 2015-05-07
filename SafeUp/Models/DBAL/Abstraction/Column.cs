using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.WebPages;
using SafeUp.Models.DBAL.Enums;
using SafeUp.Models.DBAL.Interfaces;

namespace SafeUp.Models.DBAL.Abstraction
{
    public class Column<T> : IColumn<T>
    {
        private Type _columnValueType;

        protected string ColumnName;
        protected bool FieldIsWhere;
        protected SelectClause Clause;

        //  Konstruktor też był zjebany bo przypisywane były do siebie pola przekazywane jako parametry a więc ColumnName i ColumnValue były puste.
        public Column(string columnName, T columnValue)
        {
            this._columnValueType = columnValue.GetType();
            this.ColumnName = columnName;
            this.ColumnValue = columnValue;
        }
        
        public T ColumnValue { get; set; }

        public string GetColumnName()
        {
           return ColumnName;
        }



        public Type GetColumnValueType()
        {
            return _columnValueType;
        }


        public bool IsWhere()
        {
            return FieldIsWhere;
        }


        public SelectClause GetSelectClause()
        {
            return Clause;
        }


        public void SetWhere(bool isWhere)
        {
            FieldIsWhere = isWhere;
        }
    }
}