using System.Collections.Generic; 
using SafeUp.Models.DBAL.Interfaces;

namespace SafeUp.Models.DBAL.Abstraction
{
    //tabelka w bd
    public abstract class Table : ITable
    {
        public string TableName { get; protected set; }

        public Dictionary<string, IColumn<object>> Row { get; protected set; }

        private const string ID = "id";

        public int Id
        {
            get
            {
                return (int)Row[ID].GetColumnValue();
            }

            set
            {
             SetValue(ID,value);   
            }
        }

        protected void SetValue<T>(string columnName, T columnValue)
        {
            if (Row.ContainsKey(columnName))
            {
                Row[columnName].SetColumnValue(columnValue);
            }
            else
            {
                Row.Add(columnName,new Column<object>(columnName,columnValue));
            }
        }
    
    }
}