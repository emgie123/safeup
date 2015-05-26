using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using SafeUp.Models.ActionFilters;
using SafeUp.Models.DBPOSTGREs;
using SafeUp.Models.SafeUpCollections;
using SafeUp.Models.SafeUpModels;
using SafeUp.Models.Utilities_and_Enums;
using SafeUp.Models.ViewModels.Files;
using File = SafeUp.Models.SafeUpModels.File;

namespace SafeUp.Controllers
{
    public class MyFilesController : Controller
    {
        // GET: LoggedIn

        [CustomSessionAuthorizeFilter]
        public ActionResult UserFiles(string uploadStatus)
        {
            ViewBag.UploadStatus = uploadStatus;
      
            Table<File> files;
            using (var handler = new PostgreHandler())
            {
                files = handler.GetEmptyFilesModel();

            }
            files.SelectWhere(string.Format("owner={0}",Session["ID"]));
   
            return PartialView("~/Views/Partials/LoggedIn/Files/MyFilesPartial.cshtml", files);
 
        }

        [CustomSessionAuthorizeFilter]
        public ActionResult ShareFile(int IdFile, string returnMessage="")
        {
            FileShareModelViewModel model = new FileShareModelViewModel();
            model.IdFile = IdFile;
            model.ReturnMessage = returnMessage;

            Groups groupTable;
            UserGroups userGroupsTable;
            GroupPermissions groupPermissionTable;
            Permissions permissionTable;
            Users userTable;

            using (var handler = new PostgreHandler())
            {
                groupTable = (Groups) handler.GetEmptyGroupsModel();
                userGroupsTable = (UserGroups) handler.GetEmptyUserGroupModel();
                groupPermissionTable = (GroupPermissions) handler.GetEmptyGroupPermissionsModel();
                permissionTable = (Permissions) handler.GetEmptyPermissionsModel();
                userTable = (Users) handler.GetEmptyUsersModel();
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
                bool checkNextGroup = false;
                foreach (var groupPermission in groupPermissionTable.Rows)
                {                 
                    if (groupPermission.Value.IDGroup == group.ID)
                    {
                        model.FileAddedToGroup.Add(true);
                        checkNextGroup = true;
                        break;
                    }
                }
                if (!checkNextGroup)
                {
                    model.FileAddedToGroup.Add(false);
                }                
            }

            //  Udostępnianie bezpośrednio innym użytkownikom.
            permissionTable.SendCustomGetDataQuery(string.Format("select * from \"Permission\" where \"ID_file\"={0} and \"ID_user\"!={1}", IdFile, Session["ID"]));

            foreach (var permissionsRow in permissionTable.Rows)
            {
                userTable.SelectWhere(string.Format("ID={0}", permissionsRow.Value.IDUser));
                model.UserList.Add(new User()
                {
                    ID = userTable.Rows[permissionsRow.Value.IDUser].ID,
                    Login = userTable.Rows[permissionsRow.Value.IDUser].Login,                  
                });
            }

            return PartialView("~/Views/Partials/LoggedIn/Files/ShareFilePartial.cshtml", model);
        }

        [CustomSessionAuthorizeFilter]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveFileFromGroup(int IdGroup, int IdFile)
        {
            //GroupPermissions groupPermissionsTable;
            Table<GroupPermission> groupPermissionsTable;

            using (var handler = new PostgreHandler())
            {
                groupPermissionsTable = handler.GetFilledGroupPermissionsModel();
            }

            groupPermissionsTable.SendCustomSetDataQuery(string.Format("delete from \"GroupPermission\" where \"ID_file\"={0} and \"ID_group\"={1}", IdFile, IdGroup));

            return RedirectToAction("ShareFile", new { IdFile });
        }

        [CustomSessionAuthorizeFilter]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddFileToGroup(int IdGroup, int IdFile)
        {
            GroupPermissions groupPermissionsTable;

            using (var handler = new PostgreHandler())
            {
                groupPermissionsTable = (GroupPermissions)handler.GetFilledGroupPermissionsModel();
            }

            groupPermissionsTable.SendCustomSetDataQuery(string.Format("insert into \"GroupPermission\"(\"ID\",\"ID_file\",\"ID_group\") values (default,'{0}','{1}')", IdFile, IdGroup));

            return RedirectToAction("ShareFile", new { IdFile });
        }

        [CustomSessionAuthorizeFilter]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddFileToUser(string UserName, int IdFile)
        {

            UserName = InputValidator.ValidateInputAttribute(UserName);

            Permissions permissionTable;
            Users userTable;
            string returnMessage = "";
            using (var handler = new PostgreHandler())
            {
                permissionTable = (Permissions)handler.GetFilledPermissionsModel();
                userTable = (Users) handler.GetEmptyUsersModel();
            }
            userTable.SelectWhere(string.Format("login={0}", UserName));
            if (userTable.Rows.Count == 0)
            {
                returnMessage = string.Format("Użytkownik: {0} nie istnieje w systemie.", UserName);
                return RedirectToAction("ShareFile", new { IdFile, returnMessage });
            }

            permissionTable.SendCustomGetDataQuery(string.Format("select * from \"Permission\" where \"ID_file\"='{0}' and \"ID_user\"='{1}'", IdFile, userTable.Rows.Last().Value.ID));
            if (permissionTable.Rows.Count != 0)
            {
                returnMessage = string.Format("Użytkownik: {0} posiada już dostęp do tego pliku.", UserName);
                return RedirectToAction("ShareFile", new {IdFile, returnMessage});
            }
            permissionTable.SendCustomSetDataQuery(string.Format("insert into \"Permission\"(\"ID\",\"ID_file\",\"ID_user\") values (default,'{0}','{1}')", IdFile, userTable.Rows.Last().Value.ID));

            return RedirectToAction("ShareFile", new { IdFile });
        }

        [CustomSessionAuthorizeFilter]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveFileFromUser(int IdUser, int IdFile)
        {
            Permissions permissionTable;

            using (var handler = new PostgreHandler())
            {
                permissionTable = (Permissions) handler.GetFilledPermissionsModel();
            }

            permissionTable.SendCustomSetDataQuery(string.Format("delete from \"Permission\" where \"ID_file\"={0} and \"ID_user\"={1}", IdFile, IdUser));

            return RedirectToAction("ShareFile", new { IdFile });
        }


      
        public string DownloadFile(int fileId)
        {
       
            string url = string.Empty;
            string fileName = string.Empty;
            using (var handler = new PostgreHandler())
            {
                Table<File> file = handler.GetEmptyFilesModel();
                file.SelectWhere(string.Format("ID={0}", fileId));
                url = file.Rows.First().Value.Path;
                fileName = file.Rows.First().Value.Name;
            }

            //if (!url.ToUpper().Contains("http://")) url = string.Format("http://{0}", url);

           // HttpContext.Response.AppendHeader("Content-Disposition", string.Format("attachment; filename={0}", fileName));
           // HttpContext.Response.ContentType = "application/unknown";

         
            return url;


        }


        [CustomSessionAuthorizeFilter]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadFile(string encryptedString, string name, string key, string size)
        {


         
            string uploadStatus = "Plik został dodany";

            ViewBag.UploadStatus = uploadStatus;
            return View("~/Views/LoggedIn/LoggedInView.cshtml");
        }



    }
}