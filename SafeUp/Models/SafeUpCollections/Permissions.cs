using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SafeUp.Models.DBPOSTGREs;
using SafeUp.Models.DBPOSTGREs.Interfaces;
using SafeUp.Models.SafeUpModels;

namespace SafeUp.Models.SafeUpCollections
{
    public class Permissions : Table<Permission>
    {
        public override sealed Dictionary<int, Permission> Rows { get; set; }

         public Permissions(bool fillModel,string tableName = "Permission")
             : base(tableName)
        {
             Rows = new Dictionary<int, Permission>();
             if (fillModel) FillModelWithAllData();
        }


        protected override Permission GetRowModelInstance(int id)
        {
            return new Permission(){ID=id};
        }

        public override void AddRow(Permission detailRowModel)
        {
            InsertQuery = string.Format(
                "insert into \"User\" values (default,'{0}','{1}')", detailRowModel.IDFile,
                detailRowModel.IDUser);

            PostgreClient.SetData(InsertQuery);

            base.AddRow(detailRowModel);
        }

    }
}