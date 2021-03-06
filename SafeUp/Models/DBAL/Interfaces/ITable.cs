﻿using System.Collections.Generic;
using System.Data;

namespace SafeUp.Models.DBAL.Interfaces
{
    public interface ITable
    {
        string TableName { get; }
        Dictionary<int,Dictionary<string,IColumn<object>>> Rows { get; }
        IColumn<object> GetColumn(string columnName);
        List<DataRow> GetRowsList(DataSet dataSet);
        void SetWhere(string columnName);


        //void SetWhere(string columnName);
        //List<IModel> GetDataRowsList(DataSet table);
    }
}