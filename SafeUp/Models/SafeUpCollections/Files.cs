using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SafeUp.Models.DBPOSTGREs;
using SafeUp.Models.DBPOSTGREs.Interfaces;
using SafeUp.Models.SafeUpModels;

namespace SafeUp.Models.SafeUpCollections
{
    public class Files : Table<SafeUpModels.File>
    {
        public override sealed Dictionary<int, File> Rows { get; set; }

        public Files(string tableName="File") : base(tableName)
        {
            Rows = new Dictionary<int, File>();
            FillModelWithData();
        }


        protected override File GetInstance()
        {
            return new File();
        }

        public override void AddRow(File detailRowModel)
        {
            InsertQuery = string.Format(
                "insert into \"User\" values (default,'{0}','{1}','{2}','{3}','{4}','{5}')", 
                detailRowModel.Name, detailRowModel.Path, detailRowModel.Owner, detailRowModel.CreatedOn,
                detailRowModel.Size, detailRowModel.Key);
 
            PostgreClient.SetData(InsertQuery);
        }

   
    }
}