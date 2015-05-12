using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using SafeUp.Models.ActionFilters;
using SafeUp.Models.DBPOSTGREs;
using SafeUp.Models.SafeUpCollections;
using SafeUp.Models.SafeUpModels;

namespace SafeUp.Controllers
{
    public class MyFilesController : Controller
    {
        // GET: LoggedIn

        [CustomSessionAuthorizeFilter]
        public ActionResult UserFiles()
        {
            List<File> userFiles = new List<File>();

            Table<File> files;
            using (var handler = new PostgreHandler())
            {
                files = handler.GetEmptyFilesModel();

            }
            files.SelectWhere(string.Format("owner={0}",Session["ID"]));
   
            return PartialView("~/Views/Partials/LoggedIn/Files/MyFilesPartial.cshtml", files);
 
        }

        [CustomSessionAuthorizeFilter]
        public ActionResult File()
        {
            return PartialView("~/Views/Partials/LoggedIn/Files/FileDetailsPartial.cshtml");
        }



     
    }
}