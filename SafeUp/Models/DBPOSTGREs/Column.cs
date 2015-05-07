using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SafeUp.Models.DBPOSTGREs.Interfaces;

namespace SafeUp.Models.DBPOSTGREs
{
    public class Column<T> : IColumn<T>
    {
        public Type ColumnType { get; set; }
        public T ColumnyValue { get; set; }
        public string ColumnName { get; set; }
    }
}