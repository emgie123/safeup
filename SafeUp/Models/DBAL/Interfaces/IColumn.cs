using System;
using SafeUp.Models.DBAL.Enums;

namespace SafeUp.Models.DBAL.Interfaces
{
    public interface IColumn<T>
    {

        T ColumnValue { get; set; }
        string GetColumnName();
        Type GetColumnValueType();
        bool IsWhere();
        void SetWhere(bool isWhere);
        SelectClause GetSelectClause();
    }
}