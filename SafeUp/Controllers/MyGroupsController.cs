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
            List<Group> model = new List<Group>();

            Table<Group> groups;
            Table<UserGroup> usersGroups;
            using (var handler = new PostgreHandler())
            {
                groups = handler.GetGroupsModel();
                usersGroups = handler.GetUserGroupModel();
            }
            List<UserGroup> temp = new List<UserGroup>();

            foreach (var row in usersGroups.Rows)
            {
                if (row.Value.IDUser == (int)Session["ID"])
                {
                    temp.Add(new UserGroup()
                    {
                        ID = row.Value.ID,
                        IDGroup = row.Value.IDGroup,
                        IDUser = row.Value.IDGroup
                    });
                }            
            }

            foreach (var row in temp)
            {
                var info = (from g in groups.Rows where g.Value.ID == row.IDGroup select g).ToArray();

                model.Add(new Group()
                {
                    ID = info[0].Value.ID,
                    CreatedOn = info[0].Value.CreatedOn,
                    CreatedBy = info[0].Value.CreatedBy,
                    Name = info[0].Value.Name
                });

            }


            return PartialView("~/Views/Partials/LoggedIn/Groups/MyGroupsPartial.cshtml", model);
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