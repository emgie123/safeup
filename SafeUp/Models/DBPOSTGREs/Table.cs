﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
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
            PostgreClient = new PostgreClient();
        } 


        public void DeleteRow(int rowId)
        {
            //usuniecie z kolekcji
            PostgreClient.SetData(string.Format("delete from \"{0}\" where \"ID\"={1}", TableName, rowId));
            //przeladowanie modelu 
            Rows.Remove(rowId);
    
        }

        protected abstract T GetInstance();
        public abstract void AddRow(T detailRowModel);

        public void ChangeColumnValue<TValue>(int rowId, string columnName, TValue columnValue)
        {
            columnName = string.Format("<{0}>k__BackingField", columnName);
     
            if (!Rows.ContainsKey(rowId)) throw new KeyNotFoundException();

            FieldInfo field = Rows[rowId].GetType().GetField(columnName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            if(field==null) throw new Exception("Kolumna nie istnieje");

            field.SetValue(Rows[rowId],columnValue);
        }

        public void SelectWhere(string whereClause)
        {
            string customQuery = string.Format("{0} where {1}", SelectQuery, whereClause);
            FillModelWithData(PostgreClient.GetData(customQuery));
        }

        public void SendCustomQuery(string query)
        {
            PostgreClient.SetData(query);
            FillModelWithAllData();
        }

        public void FillModelWithAllData()
        {
            FillModelWithData(PostgreClient.GetData(SelectQuery));
        }


        protected void FillModelWithData(DataSet properDataSet)
        {
            Rows.Clear();

            Ds = properDataSet;
            FieldInfo field;

            for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
            {
                var rowID = Convert.ToInt32(Ds.Tables[0].Rows[i].ItemArray[0]);
                Rows.Add(rowID, GetInstance());

                //field = Rows[rowID].GetType().BaseType.GetField("ID", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                //field.SetValue(Rows[rowID], rowID);

                for (int j = 0; j < Ds.Tables[0].Rows[i].ItemArray.Count(); j++)
                {

                    var columnValue = Ds.Tables[0].Rows[i].ItemArray[j];
                    var columnName = Ds.Tables[0].Columns[j].ToString();

                    columnName = columnName.Contains('_') ? RemoveLowDash(columnName) : FirstCharToUpper(columnName);
                    columnName = string.Format("<{0}>k__BackingField", columnName);

                    //todo tutaj jakaś flaga która zczyta tez zmienną ID która jest w TABLE a nie w konklretnej tabeli (bo teraz w user 
                    // "przykryłem" tą zmienna taką samą o tej samej nazwie to ją widzi. potestuj
                 
                
                     field = Rows[rowID].GetType()
                     .GetField(columnName, BindingFlags.Instance | BindingFlags.NonPublic);
                    
                    field.SetValue(Rows[rowID], columnValue);

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

        protected void AddRowToRowsDictionary(Table<T> detailRowModel)
        {
            var newId = Rows.Keys.Last() + 1;
            detailRowModel.ID = newId;
           // Rows.Add(newId, detailRowModel);
        }
    }
}