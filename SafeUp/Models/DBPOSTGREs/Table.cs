using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Web;
using SafeUp.Models.DB;
using SafeUp.Models.DBPOSTGREs.Factories;
using SafeUp.Models.DBPOSTGREs.Interfaces;
using SafeUp.Models.SafeUpModels;
using SafeUp.Models.Utilities_and_Enums;

namespace SafeUp.Models.DBPOSTGREs
{
    public abstract class Table<T> : ITable<T>
    {
        public string TableName { get; set; }
        protected PostgreClient PostgreClient;
        public abstract Dictionary<int, T> Rows { get; set; }

        protected string InsertQuery;
        protected string SelectQuery;

        protected Table(string tableName)
        {
            TableName = tableName;
            PostgreClient = new PostgreClient();
        } 


        public void DeleteRow(int rowId)
        {
            //usuniecie z kolekcji
            PostgreClient.SetData(string.Format("delete from \"{0}\" where \"ID\"={1}", TableName, rowId));
            //przeladowanie modelu 
            Rows.Remove(rowId);
        }

  


        public void ChangeColumnValue<TVal>(int rowId, string columnName, TVal columnValue)
        {
            columnName = string.Format("<{0}>k__BackingField", columnName);
     
            if (!Rows.ContainsKey(rowId)) throw new KeyNotFoundException();

            FieldInfo field = Rows[rowId].GetType().GetField(columnName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            if(field==null) throw new Exception("Kolumna nie istnieje");

            field.SetValue(Rows[rowId],columnValue);
        }
   
        public abstract void SendCustomQuery(string query);
        public abstract void AddRow(T detailRowModel);
        protected abstract void FillModelWithData();
    }
}