using System.Linq;
using SafeUp.Models.DBAL.Abstraction;
using SafeUp.Models.DBAL.Interfaces;
using SafeUp.Models.DBAL.Interfaces.SqlQueries;

namespace SafeUp.Models.DBAL.PostgreSqlQueries
{
    public class PostgreInsert : SqlQueries, IDbInsert
    {
        //string columnNames = string.Join(COLUMNS_DELIMITER, model.GetFields().Select(item => item.Key));

        //insert into users (id,name,costam) values ()


        public PostgreInsert()
        {
            _pattern = "insert into {0} ({1}) values ({2});";
        }
        public string InsertStatement(ITable table)
        {
            string columns = string.Join(_columnDelimiter, (table.Row.Select(column => column.Key)));
            string columnsValues = string.Join(_columnDelimiter, table.Row.Select(column => column.Value));

            return string.Format(_pattern, table.TableName, columns, columnsValues);
        }
    }
}