using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SafeUp.Models.DBPOSTGREs;
using SafeUp.Models.DBPOSTGREs.Interfaces;
using SafeUp.Models.SafeUpModels;

namespace SafeUp.Models.SafeUpCollections
{
    public class UserGroups : Table<UserGroup>
    {
         public UserGroups(string tableName = "UserGroup")
             : base(tableName)
        {
        }


        public override Dictionary<int, UserGroup> Rows { get; set; }
        public override void SendCustomQuery(string query)
        {
            throw new NotImplementedException();
        }

        public override void AddRow(UserGroup detailRowModel)
        {
            throw new NotImplementedException();
        }

        protected override void FillModelWithData()
        {
            throw new NotImplementedException();
        }
    }
}