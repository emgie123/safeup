using System.Data;
using SafeUp.Models.DB;
using SafeUp.Models.DBAL.Interfaces;
using SafeUp.Models.DBAL.Interfaces.SqlQueries;

namespace SafeUp.Models.DBAL.Abstraction
{
    public class DbHandler : IHandler
    {
        private IDbClient _client;
        private IDbInsert _insert;
        private IDbUpdate _update;
        private IDbDelete _delete;
        private IDbSelect _select;
        
        public DbHandler(IDbClient client, IDbInsert insert, IDbUpdate update, IDbDelete delete, IDbSelect select)
        {
            _client = client;
            _insert = insert;
            _update = update;
            _delete = delete;
            _select = select;

        }
        
        public DataSet GetData(ITable table)
        {
            return _client.GetData(_select.SelectStatement(table));
        }

        public int Insert(ITable table)
        {
            return _client.SetData(_insert.InsertStatement(table));
        }

        public int Update(ITable table)
        {
            return _client.SetData(_update.UpdateStatement(table));
        }

        public int Delete(ITable table)
        {
            return _client.SetData(_delete.DeleteStatement(table));
        }
    }
}