using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.WebPages;
using SafeUp.Models.DBAL.Interfaces;

namespace SafeUp.Models.DBAL.Abstraction
{
    public class Column<T> : IColumn<T>
    {
        protected string ColumnName;
        protected T ColumnValue;
        private readonly Type _columnValueType;

        //  Konstruktor też był zjebany bo przypisywane były do siebie pola przekazywane jako parametry a więc ColumnName i ColumnValue były puste.
        public Column(string columnName, T columnValue)
        {
            this._columnValueType = columnValue.GetType();
            this.ColumnName = columnName;
            this.ColumnValue = columnValue;
        }
        
        public T GetColumnValue()
        {
            //  Tu musiałem poprawić castowanie na stringa, bo inaczej select się nie wykonywał. Jak coś składnia jest taka:
            //  INSERT INTO films (code, title, did, date_prod, kind) VALUES ('T_601', 'Yojimbo', 106, '1961-06-16', 'Drama');
            //  A więc pewnie już się domyślasz o co mi chodzi. Narazie działaja inserty, ale trzeba pomyśleć czy nie można tego fajniej zrobić.
            if (_columnValueType == typeof(String))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("'" + ColumnValue + "'");
                
                ColumnValue = (T) Convert.ChangeType(sb.ToString(), TypeCode.Object);
            }
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