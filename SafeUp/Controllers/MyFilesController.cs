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
using SafeUp.Models.ViewModels.Files;

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

        [CustomSessionAuthorizeFilter]
        public ActionResult ShareFile(int IdFile)
        {
            FileShareModel model = new FileShareModel();
            model.IdFile = IdFile;

            Groups groupTable;
            UserGroups userGroupsTable;
            GroupPermissions groupPermissionTable;

            using (var handler = new PostgreHandler())
            {
                groupTable = (Groups) handler.GetEmptyGroupsModel();
                userGroupsTable = (UserGroups) handler.GetEmptyUserGroupModel();
                groupPermissionTable = (GroupPermissions) handler.GetEmptyGroupPermissionsModel();
            }

            groupTable.SelectWhere(string.Format("created_by={0}", Session["ID"]));
            userGroupsTable.SelectWhere(string.Format("ID_user={0}", Session["ID"]));
            groupPermissionTable.SelectWhere(string.Format("ID_file={0}", IdFile));    //ściągamy wszystkie grupy, które już posiadają plik

            foreach (var myGroup in groupTable.Rows)
            {
                model.GroupsList.Add(new Group(){ID = myGroup.Value.ID, CreatedOn = myGroup.Value.CreatedOn, Name = myGroup.Value.Name, CreatedBy = myGroup.Value.CreatedBy});
            }

            foreach (var userGroup in userGroupsTable.Rows)
            {
                groupTable.SendCustomGetDataQuery(string.Format("select * from \"Group\" where \"ID\" = '{0}' and \"created_by\" != '{1}'", userGroup.Value.IDGroup, Session["ID"]));
                if (groupTable.Rows.Count == 0)
                {
                    continue;
                }
                model.GroupsList.Add(new Group()
                { 
                    ID = groupTable.Rows[userGroup.Value.IDGroup].ID,
                    CreatedOn = groupTable.Rows[userGroup.Value.IDGroup].CreatedOn,
                    Name = groupTable.Rows[userGroup.Value.IDGroup].Name,
                    CreatedBy = groupTable.Rows[userGroup.Value.IDGroup].CreatedBy
                });
            }

            foreach (var group in model.GroupsList)
            {
                foreach (var groupPermission in groupPermissionTable.Rows)
                {
                    if (groupPermission.Value.IDGroup == group.ID)
                    {
                        model.FileAddedToGroup.Add(true);
                        break;
                    }
                }
                model.FileAddedToGroup.Add(false);
            }
            return PartialView("~/Views/Partials/LoggedIn/Files/ShareFilePartial.cshtml", model);
        }

        public ActionResult RemoveFileFromGroup(int IdGroup, int IdFile)
        {
            return null;
        }

        public ActionResult AddFileToGroup(int IdGroup, int IdFile)
        {
            return null;
        }



     
    }
}