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

        public override Dictionary<int, UserGroup> Rows { get; set; }

         public UserGroups(string tableName = "UserGroup")
             : base(tableName)
        {
             Rows = new Dictionary<int, UserGroup>();
             FillModelWithAllData(); ;
        }


        protected override UserGroup GetRowModelInstance(int id)
        {
            return new UserGroup(){ID = id};
        }

        public override void AddRow(UserGroup detailRowModel)
        {
            InsertQuery = string.Format(
              "insert into \"User\" values (default,'{0}','{1}')", detailRowModel.IDUser,detailRowModel.IDGroup);

            PostgreClient.SetData(InsertQuery);

            base.AddRow(detailRowModel);
        }

    }
}