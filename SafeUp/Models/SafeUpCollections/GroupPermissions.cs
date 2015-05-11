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

        public override sealed Dictionary<int, GroupPermission> Rows { get; set; }

         public GroupPermissions(string tableName = "GroupPermission")
             : base(tableName)
        {
             Rows = new Dictionary<int, GroupPermission>();
             FillModelWithData();
        }


        protected override GroupPermission GetInstance()
        {
            return new GroupPermission();
        }

        public override void AddRow(GroupPermission detailRowModel)
        {
            InsertQuery = string.Format(
                "insert into \"User\" values (default,'{0}','{1}'", detailRowModel.IdFile,detailRowModel.IdGroup);

            PostgreClient.SetData(InsertQuery);
        }

      
    }
}