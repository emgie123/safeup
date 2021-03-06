﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using SafeUp.Models.DB;
using SafeUp.Models.DBPOSTGREs.Interfaces;

namespace SafeUp.Models.DBPOSTGREs
{
    public abstract class Table<T> : ITable<T> 
    {
        public int ID { get; set; }
        public string TableName { get; set; }
        protected PostgreClient PostgreClient;
        public abstract Dictionary<int, T> Rows { get; set; }
        protected DataSet Ds;

        protected string InsertQuery;
        protected string SelectQuery;
  
        protected Table(string tableName)
        {
    
            TableName = tableName;
            SelectQuery = string.Format("select * from \"{0}\"", TableName);
            //PostgreClient = new PostgreClient();
            PostgreClient = new PostgreClient("safeup", "e9r=7q8BtYjS", "safeup.ryuu.me","safeup");
        } 


        public void DeleteRow(int rowId)
        {
            //usuniecie z kolekcji
            PostgreClient.SetData(string.Format("delete from \"{0}\" where \"ID\"={1}", TableName, rowId));
            //przeladowanie modelu 
            Rows.Remove(rowId);
    
        }

        protected abstract T GetRowModelInstance(int id);

        public virtual void AddRow(T detailRowModel)
        {
    
            var newId = Rows.Keys.Last() + 1;
            Rows.Add(newId,GetRowModelInstance(newId));
            
       
        }

        public void ChangeColumnValue<TValue>(int rowId, string columnName, TValue columnValue)
        {
           // columnName = string.Format("<{0}>k__BackingField", columnName);
     
            if (!Rows.ContainsKey(rowId)) throw new KeyNotFoundException();

            PropertyInfo field = Rows[rowId].GetType().GetProperty(columnName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            if(field==null) throw new Exception("Kolumna nie istnieje");

            field.SetValue(Rows[rowId],columnValue);
        }

        public void SelectWhere(string whereClause)
        {
            var splittedClause = whereClause.Split(new[] { "and" }, StringSplitOptions.RemoveEmptyEntries);
            string output = string.Empty;


            int lastIndex = splittedClause.Count();

            for (int i = 0; i < lastIndex; i++)
            {
                var elements = splittedClause[i].Replace(" ", "").Split('=');

                output += string.Format("\"{0}\"='{1}'", elements[0], elements[1]);
                if (i + 1 != lastIndex) output += " and ";

            }

            string customQuery = string.Format("{0} where {1}", SelectQuery, output);
            FillModelWithData(PostgreClient.GetData(customQuery));
        }

        public void SendCustomSetDataQuery(string query)
        {
            PostgreClient.SetData(query);
            FillModelWithAllData();
        }

        public void SendCustomGetDataQuery(string query)
        {
            FillModelWithData(PostgreClient.GetData(query));
        }

        public void FillModelWithAllData()
        {
            FillModelWithData(PostgreClient.GetData(SelectQuery));
        }


        protected void FillModelWithData(DataSet properDataSet)
        {
            Rows.Clear();

            Ds = properDataSet;

            for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
            {
                var rowID = Convert.ToInt32(Ds.Tables[0].Rows[i].ItemArray[0]);

                Rows.Add(rowID, GetRowModelInstance(rowID));

                for (int j = 1; j < Ds.Tables[0].Rows[i].ItemArray.Count(); j++) //od 1 bo id mozna pominac
                {

                    var columnValue = Ds.Tables[0].Rows[i].ItemArray[j];
                    var columnName = Ds.Tables[0].Columns[j].ToString();

                    columnName = columnName.Contains('_') ? RemoveLowDash(columnName) : FirstCharToUpper(columnName);
                   // columnName = string.Format("<{0}>k__BackingField", columnName);
                   // var properitiessds = Rows[rowID].GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                    var property = Rows[rowID].GetType()
                        .GetProperty(columnName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

                   if(property!=null) property.SetValue(Rows[rowID], columnValue);

                }
            }
        }

        protected  string FirstCharToUpper(string input)
        {
            return input.First().ToString().ToUpper() + String.Join("", input.Skip(1));
        }

        protected  string RemoveLowDash(string input)
        {
            var segments = input.Split('_');

            return segments.Aggregate(string.Empty, (current, segment) => current + FirstCharToUpper(segment));
        }

    }
}