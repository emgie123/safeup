using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using SafeUp.Models.DBPOSTGREs;
using SafeUp.Models.SafeUpCollections;
using SafeUp.Models.SafeUpModels;

namespace SafeUp.Controllers
{
    public class MyFilesController : Controller
    {
        // GET: LoggedIn
    

        public ActionResult UserFiles()
        {
            List<File> userFiles = new List<File>();

            Table<File> files;
            using (var handler = new PostgreHandler())
            {
                files = handler.GetFilesModel();
            }
            //foreach (var file in files.Rows)
            //{
            //    if (!file.Value.Columns["owner"].ColumnyValue.Equals(Session["ID"]))
            //    {
            //        continue;
            //    }
            //    userFiles.Add(new File()
            //    {
            //        ID = new Column<int>(){ColumnName = "ID", ColumnyValue = file.Key},
            //        Name = new Column<string>() { ColumnName = "Name", ColumnyValue = file.Value.Columns["name"].ColumnyValue.ToString()},
            //        Path = new Column<string>() { ColumnName = file.Value.Columns["path"].ColumnyValue.ToString()},
            //        Owner = new Column<int>() { ColumnName = "Owner", ColumnyValue = (int)file.Value.Columns["owner"].ColumnyValue},
            //        Size = new Column<double>() { ColumnName = "Size", ColumnyValue = (double)file.Value.Columns["size"].ColumnyValue},
            //        Key = new Column<string>() { ColumnName = "Key", ColumnyValue = file.Value.Columns["key"].ColumnyValue.ToString()},
            //        CreatedOn = new Column<DateTime>() { ColumnName = "CreatedOn", ColumnyValue = DateTime.Parse(file.Value.Columns["created_on"].ColumnyValue.ToString()) }                    
            //    });
            //}
           return PartialView("~/Views/Partials/LoggedIn/Files/MyFilesPartial.cshtml", userFiles);
 
        }

        public ActionResult File()
        {
            return PartialView("~/Views/Partials/LoggedIn/Files/FileDetailsPartial.cshtml");
        }



     
    }
}