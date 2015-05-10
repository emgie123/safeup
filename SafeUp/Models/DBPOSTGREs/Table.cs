using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
            GetAllData();
        }

        private void AddRowId(int rowID, ModelFactory modelFactory)
        {
            Rows.Add(rowID, modelFactory.GetProperModel(TableName.ToUpper()));
            Rows.Values.Last().RowId = rowID;
      
        }

        private void GetAllData()
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
                        AddRowId((int)ds.Tables[0].Rows[i].ItemArray[j], modelFactory);
                        addRowBool = false;
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
        }

        public void DeleteRow(int rowId)
        {
            //usuniecie z kolekcji
            PostgreClient.SetData(string.Format("delete from \"{0}\" where \"ID\"={1}", TableName, rowId));
            //przeladowanie modelu 
            Rows.Remove(rowId);
        }

        public virtual void AddRow(params string[] args)
        {
            //Jakby co to można nadpisać to w klasach potomnych gdzie już wiadomo ile ma być kolumn dzięki czemu
            //zwiększy się wydajnośc no ( w sumie tak samo jak w przypadku GetAllRows);

            string query = String.Format("select * from \"{0}\";", TableName);
            DataSet ds = PostgreClient.GetData(query);


            if (args.Count() != ds.Tables[0].Columns.Count-1) //-1 bo ID nie podajemy
            {
                throw new Exception(string.Format("Ilość podanych kolumn nie zgadza się z bazą. Nie należy podawać ID, Podano {0} / {1}",args.Count(),ds.Tables[0].Columns.Count));
            }

            var lastRow = ds.Tables[0].Rows.Count - 1;
            var newID = (int) ds.Tables[0].Rows[lastRow].ItemArray[0] + 1;

            string paramsValues = string.Format("'{0}',", newID);

            for (int i = 1; i < ds.Tables[0].Columns.Count; i++) //od 1 zeby pominąć ID
            {
                paramsValues += string.Format("'{0}'",args[i-1]); //i-1 zeby sie nie wywaliło (jest mniej args niz columns.count)
                if (i < ds.Tables[0].Columns.Count - 1)
                {
                    paramsValues += ",";
                }
            }

            var insertQuery = string.Format("insert into \"{0}\" values ({1});",TableName,paramsValues);
            PostgreClient.SetData(insertQuery);

            //dodanie wiersza do słownika
            ModelFactory modelFactory = new ModelFactory();
            AddRowId(newID, modelFactory);

         
            string[] argsWithId = new string[args.Count() + 1];
            argsWithId[0] = newID.ToString();

            for (int i = 1; i < argsWithId.Count(); i++)
            {
                argsWithId[i] = args[i - 1];
            }

            for (int j = 0; j < args.Count(); j++)
            {
                string columnName = ds.Tables[0].Columns[j].ColumnName; 
                Type columnType = ds.Tables[0].Columns[j].DataType;

                Rows.Values.Last().Columns.Add(columnName, new Column<object>()
                {
                    ColumnName = columnName,
                    //  todo poprawić by columna była rzeczywiście danego typu a nie tak jak jest teraz typ object.
                    // nie da sie, musimy jakos inaczej to obejsc
                    ColumnType = columnType,
                    ColumnyValue = argsWithId[j]
                });
            }
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