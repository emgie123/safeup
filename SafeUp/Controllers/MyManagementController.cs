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
         
            Session.Timeout = 5;

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
        public ActionResult ShowGroupUsers(int groupId, string groupName,string message="")
        {

            ManagementViewModel groupUsersModel = new ManagementViewModel
            {
                GroupName = groupName,
                GroupId = groupId,
                Message = message
            };

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
        public ActionResult AddUserToGroup(string userLogin, int groupId, string groupName)
        {

            string message = string.Empty;

            using (var handler = new PostgreHandler())
            {
                 
                Table<User> users = handler.GetEmptyUsersModel();
                users.SendCustomGetDataQuery(string.Format("select * from \"User\" where \"login\"='{0}'", userLogin));


                if (users.Rows.Count < 1)
                {
                    message= "Użytkownik nie istnieje";
                    return RedirectToAction("ShowGroupUsers", new { groupId, groupName, message });
                }

                Table<UserGroup> group = handler.GetEmptyUserGroupModel();
                group.SendCustomGetDataQuery(string.Format("select * from \"UserGroup\" where \"ID_user\"={0} and \"ID_group\"={1}", users.Rows.First().Value.ID, groupId));

                if (group.Rows.Count > 0)
                {
                    message = "Użytkownik widnieje już w tej grupie";
                    return RedirectToAction("ShowGroupUsers", new { groupId, groupName, message });
                }

                group.SendCustomSetDataQuery(string.Format("insert into \"UserGroup\" values (default,'{0}','{1}')",groupId,users.Rows.First().Value.ID));
                  


            }
            return RedirectToAction("ShowGroupUsers", new { groupId, groupName, message });

        }

    }
}