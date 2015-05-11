using System.Collections.Generic;

namespace SafeUp.Models.DBPOSTGREs.Interfaces
{
    public interface ITable<T>
    {
        string TableName { get; set; }
        Dictionary<int, T> Rows { get; set; }

        //void GetAllData();
        void DeleteRow(int rowId);
        void AddRow(T detailRowModel);
        void ChangeColumnValue<TVal>(int rowId, string columnName,TVal columnValue);

        void SendCustomQuery(string query);



    }
}