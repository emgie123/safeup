using System.Collections.Generic;
using System.Data;
using System.Linq;
using SafeUp.Models.DBAL.Interfaces;

namespace SafeUp.Models.DBAL.Abstraction
{
    //tabelka w bd
    public abstract class  Table : ITable
    {
        public string TableName { get; protected set; }

        public Dictionary<int,Dictionary<string,IColumn<object>>> Rows  { get; protected set; }

        protected Table()
        {
            Rows = new Dictionary<int, Dictionary<string, IColumn<object>>>();
        }


        protected void SetValue<T>(int rowId, string columnName, T columnValue)
        {
            if (Rows.ContainsKey(rowId))
            {
                Rows[rowId][columnName].ColumnValue = columnValue;
            }
            else
            {
               Rows.Add(rowId,new Dictionary<string, IColumn<object>>());
            }
        }

        public IColumn<object> GetColumn(string columnName)
        {
            if (Row.ContainsKey(columnName))
            {
                return Row[columnName];
            }
            throw new KeyNotFoundException("Kolumna nie istnieje");
        }

        public List<DataRow> GetRowsList(DataSet dataSet)
        {
            return dataSet.Tables[0].Rows.OfType<DataRow>().Select(row => row).ToList();
        }


        public void SetWhere(string columnName)
        {
          //  if (Row.ContainsKey(columnName))
            {
            //    Row[columnName].SetWhere(true);
            }
        }
    }
}