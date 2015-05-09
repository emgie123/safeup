using System.Collections.Generic;

namespace SafeUp.Models.DBPOSTGREs.Interfaces
{
    public interface ITable
    {
        string TableName { get; set; }
        Dictionary<int, IRow> Rows { get; set; }

        void GetAllData();
        void DeleteRow(int rowId);
        void ChangeColumnValue<T>(int rowId, string columnName,T columnValue);

        void SendCustomQuery(string query);



    }
}