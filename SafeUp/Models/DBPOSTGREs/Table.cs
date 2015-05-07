using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using SafeUp.Models.DB;
using SafeUp.Models.DBPOSTGREs.Interfaces;

namespace SafeUp.Models.DBPOSTGREs
{
    public abstract class Table : ITable
    {

        public string TableName { get; set; }
        public abstract Dictionary<int, IRow> Rows { get; set; }
        protected PostgreClient PostgreClient;

        protected Table(string tableName)
        {
            TableName = tableName;
            PostgreClient = new PostgreClient();
        }


        public void GetAllData()
        {
            string query = String.Format("select * from {0};", TableName);

            DataSet tableData = PostgreClient.GetData(query);

            //pobranie danych
        }

        public void DeleteRow(int rowId)
        {
            PostgreClient.SetData(string.Format("delete from {0} where id={1}", TableName, rowId));
        }

 

        public void ChangeColumnValue<T>(int rowId, string columnName,T columnValue)
        {
            if (!Rows.ContainsKey(rowId)) throw new KeyNotFoundException();
            if(!Rows[rowId].Columns.ContainsKey(columnName)) throw new KeyNotFoundException();

            Rows[rowId].Columns[columnName].ColumnyValue = columnValue;
        }

        public void SendQuery(string query)
        {
            PostgreClient.SetData(query);
        }
    }
}