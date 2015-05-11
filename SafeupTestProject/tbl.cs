using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SafeUp.Models.DBPOSTGREs;
using SafeUp.Models.SafeUpModels;

namespace SafeupTestProject
{
    class tbl : Table<User>
    {
        public tbl(string tableName) : base(tableName)
        {
        }


        public override Dictionary<int, User> Rows { get; set; }
        public override void SendCustomQuery(string query)
        {
            throw new NotImplementedException();
        }

        public override void AddRow(User detailRowModel)
        {
            throw new NotImplementedException();
        }

        protected override void FillModelWithData()
        {
            throw new NotImplementedException();
        }
    }
}
