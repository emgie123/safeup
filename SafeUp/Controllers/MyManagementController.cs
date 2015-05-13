using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SafeUp.Models.ActionFilters;
using SafeUp.Models.DBPOSTGREs;
using SafeUp.Models.SafeUpModels;
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
        public ActionResult ShowGroupUsers()
        {
            return null;
        }
    }
}