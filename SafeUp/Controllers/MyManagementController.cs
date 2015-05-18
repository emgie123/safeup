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
using SafeUp.Models.ViewModels.Management;

namespace SafeUp.Controllers
{
    public class MyManagementController : Controller
    {
        [CustomSessionAuthorizeFilter]
        public ActionResult UserManagement(string message="")
        {
    

            Table<Group> groups;

            using (var handler = new PostgreHandler())
            {
                groups = handler.GetEmptyGroupsModel();
                groups.SelectWhere(string.Format("created_by={0}", Session["ID"]));
            }

            MyGroupsManagementViewModel ownedGroupsModel = new MyGroupsManagementViewModel
            {
                MyGroups = groups.Rows.Values.Select(
                    group => new OwnerOfGroup() {Name = @group.Name, CreatedOn = @group.CreatedOn, ID = @group.ID}).ToList(),
                    Message = message
                    
            };



            return PartialView("~/Views/Partials/LoggedIn/Management/MyManagementPartial.cshtml", ownedGroupsModel);
        }

        [CustomSessionAuthorizeFilter]
        public ActionResult ShowGroupUsers(int groupId, string groupName,string message="")
        {

            SpecificGroupManagementViewModel groupUsersModel = new SpecificGroupManagementViewModel
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveUserFromGroup(int userId,int groupId, string groupName)
        {
            
            using (var handler = new PostgreHandler())
            {
                Table<UserGroup> userGroups = handler.GetEmptyUserGroupModel();
                userGroups.SendCustomSetDataQuery(string.Format("delete from \"UserGroup\" where \"ID_user\"='{0}' and \"ID_group\"='{1}'",userId,groupId));
                
            }

            return RedirectToAction("ShowGroupUsers", new { groupId, groupName });
        }


        [CustomSessionAuthorizeFilter]
        [HttpPost]
        [ValidateAntiForgeryToken]
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

                group.SendCustomSetDataQuery(string.Format("insert into \"UserGroup\"(\"ID\",\"ID_user\",\"ID_group\") values (default,'{0}','{1}')",users.Rows.First().Value.ID,groupId));
                  


            }
            return RedirectToAction("ShowGroupUsers", new { groupId, groupName, message });

        }



        [CustomSessionAuthorizeFilter]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddGroup(string groupName)
        {

          ;

            using (var hander = new PostgreHandler())
            {
                Table<Group> groups = hander.GetEmptyGroupsModel();
                groups.SendCustomGetDataQuery(string.Format("select * from \"Group\" where \"name\"='{0}'",groupName));

                if (groups.Rows.Values.Count > 0)
                {
                    string message = "Taka grupa już istnieje";
                    return RedirectToAction("UserManagement", new {message});
                }

                groups.SendCustomSetDataQuery(string.Format("insert into \"Group\"(\"ID\",\"created_on\",\"created_by\",\"name\") values (default,'{0}','{1}','{2}')", DateTime.Now, Session["ID"], groupName));

            }

            return RedirectToAction("UserManagement");
        }

        [CustomSessionAuthorizeFilter]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult RemoveGroup(int groupId)
        {
          
            
            using (var hander = new PostgreHandler())
            {//TODO group permission
                Table<UserGroup> userGroups = hander.GetEmptyUserGroupModel();
                userGroups.SendCustomSetDataQuery(string.Format("delete from \"UserGroup\" where \"ID_group\"='{0}'",groupId));
                
                Table<Group> groups = hander.GetEmptyGroupsModel();
                groups.SendCustomSetDataQuery(string.Format("delete from \"Group\" where \"ID\"='{0}'",groupId));
            }

            return RedirectToAction("UserManagement");
        }


    }
}