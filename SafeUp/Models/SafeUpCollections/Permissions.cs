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

         public Permissions(string tableName = "Permission")
             : base(tableName)
        {
             Rows = new Dictionary<int, Permission>();
             FillModelWithData();
        }


        protected override Permission GetInstance()
        {
            return new Permission();
        }

        public override void AddRow(Permission detailRowModel)
        {
            InsertQuery = string.Format(
                "insert into \"User\" values (default,'{0}','{1}'", detailRowModel.IdFile,
                detailRowModel.IdUser);

            PostgreClient.SetData(InsertQuery);
        }

    }
}