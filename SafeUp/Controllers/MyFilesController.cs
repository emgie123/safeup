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
            foreach (var file in files.Rows)
            {
                if(!file.Value.Owner.Equals(Session["ID"]))
                {
                    continue;
                }
                userFiles.Add(new File()
                {
                    ID = file.Key,
                    Name = file.Value.Name,
                    CreatedOn = file.Value.CreatedOn,
                    Size = file.Value.Size
                });
            }
           return PartialView("~/Views/Partials/LoggedIn/Files/MyFilesPartial.cshtml", userFiles);
 
        }

        public ActionResult File()
        {
            return PartialView("~/Views/Partials/LoggedIn/Files/FileDetailsPartial.cshtml");
        }



     
    }
}