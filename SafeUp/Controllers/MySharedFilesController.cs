using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SafeUp.Models.ActionFilters;
using SafeUp.Models.DBPOSTGREs;
using SafeUp.Models.SafeUpModels;
using SafeUp.Models.ViewModels.SharedFiles;

namespace SafeUp.Controllers
{
    public class MySharedFilesController : Controller
    {
        [CustomSessionAuthorizeFilter]
        public ActionResult UserSharedFiles()
        {
            Table<File> permittedFiles;
            Table<File> groupPermittedFiles;
            Table<Group> groups;
            Table<User> users;

            using (var handler = new PostgreHandler())
            {
              

                string selectQuery =
                    string.Format(
                        "select * from \"File\" where \"ID\" in (select \"ID\" from \"Permission\" where \"ID_user\" = '{0}')", Session["ID"]);
                permittedFiles = handler.GetEmptyFilesModel();
                permittedFiles.SendCustomGetDataQuery(selectQuery);

                selectQuery =
                    string.Format(
                        "select * from \"File\" where \"ID\" in (select \"ID_file\" from \"GroupPermission\" where \"ID_group\" in (select \"ID_group\" from \"UserGroup\" where \"ID_user\" ='{0}'))",Session["ID"]);

                groupPermittedFiles = handler.GetEmptyFilesModel();
                groupPermittedFiles.SendCustomGetDataQuery(selectQuery);

          

              
            }

      
            AllUserSharedFiles allSharedFilesModel = new AllUserSharedFiles();

            foreach (var permittedFile in permittedFiles.Rows.Values)
            {

                using (var handler = new PostgreHandler())
                {
                    users = handler.GetEmptyUsersModel();
                    users.SelectWhere(string.Format("ID={0}", permittedFile.Owner));
               
                }

                allSharedFilesModel.SharedFilesToUser.Add(new SharedFilesToUser() { CreatedOn = permittedFile.CreatedOn, Name = permittedFile.Name, Size = permittedFile.Size,Owner = users.Rows.First().Value.Login}); 
            }


            foreach (var groupPermittedFile in groupPermittedFiles.Rows.Values)
            {

                using (var handler = new PostgreHandler())
                {
                    groups = handler.GetEmptyGroupsModel();
                    groups.SendCustomGetDataQuery(string.Format("select * from \"Group\" where \"ID\" in (select \"ID_group\" from \"GroupPermission\" where \"ID_file\"='{0}')", groupPermittedFile.ID));

                }
                allSharedFilesModel.SharedFilesToGroup.Add(new SharedFilesToGroup() { CreatedOn = groupPermittedFile.CreatedOn, Name = groupPermittedFile.Name, Size = groupPermittedFile.Size, GroupName = groups.Rows.First().Value.Name });
            }




            return PartialView("~/Views/Partials/LoggedIn/SharedFiles/MySharedFilesPartial.cshtml", allSharedFilesModel);
        }

    }
}