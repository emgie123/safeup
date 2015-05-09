using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using SafeUp.Models.DB;
using SafeUp.Models.DBPOSTGREs.Factories;
using SafeUp.Models.DBPOSTGREs.Interfaces;

namespace SafeUp.Models.DBPOSTGREs
{
    public abstract class Table : ITable
    {

        public string TableName { get; set; }
        public Dictionary<int, IRow> Rows { get; set; }
        protected PostgreClient PostgreClient;

        protected Table(string tableName)
        {
            TableName = tableName;
            Rows = new Dictionary<int, IRow>();
            PostgreClient = new PostgreClient();
        }

        private void AddRowId(int rowID, ref ModelFactory modelFactory,ref bool addRowBool)
        {
            Rows.Add(rowID, modelFactory.GetProperModel(TableName.ToUpper()));
            Rows.Values.Last().RowId = rowID;
            addRowBool = false;
        }

        public void GetAllData()
        {
            string query = String.Format("select * from \"{0}\";", TableName);

            DataSet ds = PostgreClient.GetData(query);
            ModelFactory modelFactory = new ModelFactory();

            bool addRowBool = true;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                
               // Rows.Add(i, modelFactory.GetProperModel(TableName.ToUpper()));
               // Rows.Values.Last().RowId = i;

                addRowBool = true; // dodaje id tylko raz, z wartoscia sciagnieta z bazy
            
                for (int j = 0; j < ds.Tables[0].Rows[i].ItemArray.Count(); j++)
                {
                    string columnName = ds.Tables[0].Columns[j].ColumnName;
                    Type columnType = ds.Tables[0].Columns[j].DataType;

                    if (addRowBool)
                    {
                        AddRowId((int)ds.Tables[0].Rows[i].ItemArray[j],ref  modelFactory, ref addRowBool);
                    }

                   Rows.Values.Last().Columns.Add(columnName, new Column<object>()
                    {
                        ColumnName = columnName,
                        //  todo poprawić by columna była rzeczywiście danego typu a nie tak jak jest teraz typ object.
                        // nie da sie, musimy jakos inaczej to obejsc
                        ColumnType = columnType,
                        ColumnyValue = ds.Tables[0].Rows[i].ItemArray[j]
                    });
                }
     
             
            }

            foreach (DataColumn column in ds.Tables[0].Columns)
            {
                var col = column.ColumnName;
                
       
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Debug.WriteLine(row[col]);
                }


            }
        }

        public void DeleteRow(int rowId)
        {
            //usuniecie z kolekcji
            PostgreClient.SetData(string.Format("delete from \"{0}\" where \"ID\"={1}", TableName, rowId));
            //przeladowanie modelu 
            Rows.Remove(rowId);
        }

 
        public void ChangeColumnValue<T>(int rowId, string columnName,T columnValue)
        {
            if (!Rows.ContainsKey(rowId)) throw new KeyNotFoundException();
            if(!Rows[rowId].Columns.ContainsKey(columnName)) throw new KeyNotFoundException();

            Rows[rowId].Columns[columnName].ColumnyValue = columnValue;
        }

        public void SendCustomQuery(string query)
        {
            PostgreClient.SetData(query);
            //przeladowanie modelu 
            Rows.Clear();
            GetAllData();
        }
    }
}