using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SafeUp.Models.DBPOSTGREs;
using SafeUp.Models.DBPOSTGREs.Interfaces;
using SafeUp.Models.SafeUpModels;

namespace SafeUp.Models.SafeUpCollections
{
    public class Groups : Table<SafeUpModels.Group>
    {
        public override sealed Dictionary<int, Group> Rows { get; set; }

         public Groups(string tableName = "Group")
             : base(tableName)
        {
             Rows = new Dictionary<int, Group>();
        }


        protected override Group GetInstance()
        {
           return new Group();
        }

        public override void AddRow(Group detailRowModel)
        {
            InsertQuery = string.Format(
                "insert into \"User\" values (default,'{0}','{1}','{2}'",detailRowModel );

            PostgreClient.SetData(InsertQuery);
        }

   
    }
}