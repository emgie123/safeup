using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SafeUp.Models.DBPOSTGREs;
using SafeUp.Models.DBPOSTGREs.Interfaces;
using SafeUp.Models.SafeUpModels;

namespace SafeUp.Models.SafeUpCollections
{
    public class GroupPermissions : Table<GroupPermission>
    {
         public GroupPermissions(string tableName = "GroupPermission")
             : base(tableName)
        {
        }


        public override Dictionary<int, GroupPermission> Rows { get; set; }
        public override void SendCustomQuery(string query)
        {
            throw new NotImplementedException();
        }

        public override void AddRow(GroupPermission detailRowModel)
        {
            throw new NotImplementedException();
        }

        protected override void FillModelWithData()
        {
            throw new NotImplementedException();
        }
    }
}