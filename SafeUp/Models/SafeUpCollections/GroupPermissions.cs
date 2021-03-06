﻿using System;
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

         public GroupPermissions(bool fillModel,string tableName = "GroupPermission")
             : base(tableName)
        {
             Rows = new Dictionary<int, GroupPermission>();
             if (fillModel) FillModelWithAllData();
        }


        protected override GroupPermission GetRowModelInstance(int id)
        {
            return new GroupPermission(){ID = id};
        }

        public override void AddRow(GroupPermission detailRowModel)
        {
            InsertQuery = string.Format(
                "insert into \"User\" values (default,'{0}','{1}')", detailRowModel.IDFile,detailRowModel.IDGroup);

            PostgreClient.SetData(InsertQuery);

            base.AddRow(detailRowModel);
        }

      
    }
}