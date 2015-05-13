using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SafeUp.Models.ActionFilters;
using SafeUp.Models.DBPOSTGREs;
using SafeUp.Models.SafeUpModels;
using SafeUp.Models.ViewModels;
using SafeUp.Models.ViewModels.Groups;

namespace SafeUp.Controllers
{
    public class MyManagementController : Controller
    {
        [CustomSessionAuthorizeFilter]
        public ActionResult UserManagement()
        {

            Table<Group> groups;

            using (var handler = new PostgreHandler())
            {
                groups = handler.GetEmptyGroupsModel();
                groups.SelectWhere(string.Format("created_by={0}", Session["ID"]));
            }

            List<OwnerOfGroup> ownedGroupsModel = groups.Rows.Values.Select(
                group => new OwnerOfGroup() { Name = group.Name, CreatedOn = group.CreatedOn, ID = group.ID }).ToList();


            return PartialView("~/Views/Partials/LoggedIn/Management/MyManagementPartial.cshtml", ownedGroupsModel);
        }

        [CustomSessionAuthorizeFilter]
        public ActionResult ShowGroupUsers(int groupId, string groupName)
        {

            ManagementViewModel groupUsersModel = new ManagementViewModel();
            groupUsersModel.GroupName = groupName;
            groupUsersModel.GroupId = groupId;

            using (var handler = new PostgreHandler())
            {
                groupUsersModel.UsersList = handler.GetEmptyUsersModel();
                groupUsersModel.UsersList.SendCustomGetDataQuery(string.Format("select * from \"User\" where \"ID\" in (select \"ID_user\" from \"UserGroup\" where \"ID_group\"='{0}');", groupId));
            }


            return PartialView("~/Views/Partials/LoggedIn/Management/GroupManagementUsersListPartial.cshtml",groupUsersModel);
        }

        [CustomSessionAuthorizeFilter]
        public ActionResult RemoveUserFromGroup(int userId,int groupId, string groupName)
        {
            Table<UserGroup> userGroups;
            using (var handler = new PostgreHandler())
            {
                userGroups = handler.GetEmptyUserGroupModel();
                userGroups.SendCustomSetDataQuery(string.Format("delete from \"UserGroup\" where \"ID_user\"='{0}' and \"ID_group\"='{1}'",userId,groupId));
                
            }

            return RedirectToAction("ShowGroupUsers", new { groupId, groupName });
        }


        [CustomSessionAuthorizeFilter]
        public ActionResult AddUserToGroup(int userId, int groupId)
        {

            return null;
        }

    }
}