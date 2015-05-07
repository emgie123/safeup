using System;

namespace SafeUp.Models.DBPOSTGREs.Interfaces
{
    public interface IColumn<T>
    {
        Type ColumnType { get; set; }
        T ColumnyValue { get; set; }
        string ColumnName { get; set; }
    }
}
