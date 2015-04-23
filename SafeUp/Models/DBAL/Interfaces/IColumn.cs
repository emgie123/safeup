using System;
using SafeUp.Models.DBAL.Enums;

namespace SafeUp.Models.DBAL.Interfaces
{
    public interface IColumn<T>
    {
 
        T GetColumnValue();
        string GetColumnName();
        void SetColumnValue(T columnValue);
        Type GetColumnValueType();
        bool IsWhere();
        void SetWhere(bool isWhere);
        SelectClause GetSelectClause();
    }
}