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

        public Files(bool fillModel,string tableName="File") : base(tableName)
        {
            Rows = new Dictionary<int, File>();
            if (fillModel) FillModelWithAllData();
        }


        protected override File GetRowModelInstance(int id)
        {
            return new File() {ID = id};
        }

        public override void AddRow(File detailRowModel)
        {
            InsertQuery = string.Format(
                "insert into \"User\" values (default,'{0}','{1}','{2}','{3}','{4}','{5}')", 
                detailRowModel.Name, detailRowModel.Path, detailRowModel.Owner, detailRowModel.CreatedOn,
                detailRowModel.Size, detailRowModel.Key);
 
            PostgreClient.SetData(InsertQuery);

            var newId = Rows.Keys.Last() + 1;
            detailRowModel.ID = newId;
            Rows.Add(newId, detailRowModel);

            base.AddRow(detailRowModel);
        }

   
    }
}