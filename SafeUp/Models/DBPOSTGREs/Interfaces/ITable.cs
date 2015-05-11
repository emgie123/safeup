using System.Collections.Generic;

namespace SafeUp.Models.DBPOSTGREs.Interfaces
{
    public interface ITable<T>
    {
        int ID { get; set; }
        string TableName { get; set; }
        Dictionary<int, T> Rows { get; set; }

        //void GetAllData();
        void DeleteRow(int rowId);
        void AddRow(T detailRowModel);
        void ChangeColumnValue<TValue>(int rowId, string columnName,TValue columnValue);

        void FillModelWithAllData();
        void SelectWhere(string whereClause);

        void SendCustomQuery(string query);



    }
}