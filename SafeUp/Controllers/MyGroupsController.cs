using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SafeUp.Models.DBPOSTGREs;
using SafeUp.Models.SafeUpModels;

namespace SafeUp.Controllers
{
    public class MyGroupsController : Controller
    {
        // GET: MyGroups
     
        public ActionResult UserGroups()
        {

            return PartialView("~/Views/Partials/LoggedIn/Groups/MyGroupsPartial.cshtml");
        }

      //  public ActionResult UserFiles()
     //   {
         //   List<Group> userGroups = new List<Group>();

         //   Table<Group> groups;
            //using (var handler = new PostgreHandler())
            //{
            //    groups = handler.GetFilesModel();
            //}
            //foreach (var file in files.Rows)
            //{
            //    if (!file.Value.Owner.Equals(Session["ID"]))
            //    {
            //        continue;
            //    }
            //    userFiles.Add(new File()
            //    {
            //        ID = file.Key,
            //        Name = file.Value.Name,
            //        CreatedOn = file.Value.CreatedOn,
            //        Size = file.Value.Size
            //    });
            //}
           // return PartialView("~/Views/Partials/LoggedIn/Files/MyFilesPartial.cshtml", userFiles);

       // }

        public ActionResult Group()
        {
            return PartialView("~/Views/Partials/LoggedIn/Files/GroupDetailsPartial.cshtml");
        }


    }
}