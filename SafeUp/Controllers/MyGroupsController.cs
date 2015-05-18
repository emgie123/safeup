using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SafeUp.Models.ActionFilters;
using SafeUp.Models.DBPOSTGREs;
using SafeUp.Models.SafeUpCollections;
using SafeUp.Models.SafeUpModels;
using SafeUp.Models.ViewModels;
using SafeUp.Models.ViewModels.Groups;

namespace SafeUp.Controllers
{
    public class MyGroupsController : Controller
    {
        // GET: MyGroups

        [CustomSessionAuthorizeFilter]
        public ActionResult UserGroups()
        {
            int SessionID = (int) Session["ID"];
            AllUserGroupsViewModel model = new AllUserGroupsViewModel();
            Table<Group> groups;
            Table<UserGroup> usersGroups;
            Table<User> users;
            using (var handler = new PostgreHandler())
            {
                groups = handler.GetEmptyGroupsModel();
                usersGroups = handler.GetEmptyUserGroupModel();
                users = handler.GetEmptyUsersModel();
            }

            groups.SelectWhere(string.Format("created_by={0}", Session["ID"])); //grupy ktorych jest wlasicicelem
            usersGroups.SelectWhere(string.Format("ID_user={0}", Session["ID"])); //do ktorych nalezy

            foreach (var group in groups.Rows.Values)
            {
                model.OwnedGroups.Add(new OwnerOfGroupViewModel(){Name = group.Name,CreatedOn = group.CreatedOn, ID = group.ID});
            }

            foreach (var usersGroup in usersGroups.Rows.Values)
            {
                groups.SelectWhere(string.Format("ID={0}", usersGroup.IDGroup));  //pobieramy informacje o grupie (szczegóły)
                users.SelectWhere(string.Format("ID={0}", groups.Rows[usersGroup.IDGroup].CreatedBy)); 

                model.MemberedGroups.Add(new MemberOfGroup() { CreatedBy = users.Rows.FirstOrDefault().Value.Login, CreatedOn = groups.Rows.FirstOrDefault().Value.CreatedOn, Name = groups.Rows.FirstOrDefault().Value.Name, ID = groups.Rows.FirstOrDefault().Value.ID });
            }
            
            return PartialView("~/Views/Partials/LoggedIn/Groups/MyGroupsPartial.cshtml", model);
        }

        [CustomSessionAuthorizeFilter]
        public ActionResult ShowGroupFiles(int groupNumber)
        {
            AllGroupFilesViewModel model = new AllGroupFilesViewModel();

            Table<File> groupFiles;
            Table<Group> groupTable;

            using (var handler = new PostgreHandler())
            {
                groupFiles = handler.GetEmptyFilesModel();
                groupTable = handler.GetEmptyGroupsModel();
                groupTable.SelectWhere(string.Format("ID={0}", groupNumber));
                groupFiles.SendCustomGetDataQuery(string.Format("select * from \"File\" where \"ID\" in (select \"ID_file\" from \"GroupPermission\" where \"ID_group\" = '{0}')",groupNumber));
            }

            foreach (var file in groupFiles.Rows)
            {
                model.FileList.Add(new File(){ID = file.Value.ID, CreatedOn = file.Value.CreatedOn, Name = file.Value.Name, Owner = file.Value.Owner, Size = file.Value.Size});
            }

            model.GroupName = groupTable.Rows[groupNumber].Name;

            return PartialView("~/Views/Partials/LoggedIn/Groups/GroupFilesPartial.cshtml", model);
        }

        [CustomSessionAuthorizeFilter]
        public ActionResult ShowMyFilesToAddToGroup(int groupId)
        {

            MyFilesToAddToGroupViewModel myFilesToAddToGroup = new MyFilesToAddToGroupViewModel()
            {
                GroupId = groupId
            };
            
            using (var handler = new PostgreHandler())
            {
                myFilesToAddToGroup.FilesAvailableToAddToGroup = handler.GetEmptyFilesModel();
                myFilesToAddToGroup.FilesToRemoveFromGroup = handler.GetEmptyFilesModel();

                var groups = handler.GetEmptyGroupsModel();
                groups.SelectWhere(string.Format("ID={0}",groupId));
                myFilesToAddToGroup.GroupName = groups.Rows.First().Value.Name;

            }
            myFilesToAddToGroup.FilesAvailableToAddToGroup.SendCustomGetDataQuery(string.Format("select * from \"File\" where \"owner\"={0} and \"ID\" not in (select \"ID_file\" from \"GroupPermission\" where \"ID_group\"={1})",Session["ID"],groupId));
            myFilesToAddToGroup.FilesToRemoveFromGroup.SendCustomGetDataQuery(string.Format("select * from \"File\" where \"owner\"={0} and \"ID\" in (select \"ID_file\" from \"GroupPermission\" where \"ID_group\"={1})", Session["ID"], groupId));
        
            return PartialView("~/Views/Partials/LoggedIn/Groups/MyFilesToAddToGroupPartial.cshtml", myFilesToAddToGroup);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomSessionAuthorizeFilter]
        public ActionResult AddFileToGroupAndToMyFiles(int groupId)
        {//TODO ta akcja dla plików których ziomuś nie ma u siebie jeszcze
            return null;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomSessionAuthorizeFilter]
        public ActionResult AddExistingFileToGroup(int fileId,int groupId)
        {
            using (var handler = new PostgreHandler())
            {

                Table<GroupPermission> groupPermission = handler.GetEmptyGroupPermissionsModel();

                groupPermission.SendCustomSetDataQuery(string.Format("insert into \"GroupPermission\"(\"ID\",\"ID_file\",\"ID_group\") values (default,{0},{1})",fileId,groupId));

            }

            return RedirectToAction("ShowMyFilesToAddToGroup", new { groupId });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomSessionAuthorizeFilter]
        public ActionResult RemoveFileFromGroup(int fileId, int groupId)
        {
            using (var handler = new PostgreHandler())
            {

                Table<GroupPermission> groupPermission = handler.GetEmptyGroupPermissionsModel();

                groupPermission.SendCustomSetDataQuery(string.Format("delete from \"GroupPermission\" where \"ID_file\"={0} and \"ID_group\"={1}", fileId, groupId));

            }

            return RedirectToAction("ShowMyFilesToAddToGroup", new {groupId});
        }


    }
}