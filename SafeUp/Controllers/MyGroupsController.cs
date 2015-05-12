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
            AllUserGroups model = new AllUserGroups();
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
                model.OwnedGroups.Add(new OwnerOfGroup(){Name = group.Name,CreatedOn = group.CreatedOn, ID = group.ID});
            }

            foreach (var usersGroup in usersGroups.Rows.Values)
            {
                   
                    using (var handler = new PostgreHandler())
                    { 
                        groups.SelectWhere(string.Format("ID={0}",usersGroup.IDGroup));  //pobieramy informacje o grupie (szczegóły)
                        users.SelectWhere(string.Format("ID={0}", groups.Rows[usersGroup.IDGroup].CreatedBy)); 
                    }

                    model.MemberedGroups.Add(new MemberOfGroup() { CreatedBy = users.Rows.FirstOrDefault().Value.Login, CreatedOn = groups.Rows.FirstOrDefault().Value.CreatedOn, Name = groups.Rows.FirstOrDefault().Value.Name, ID = groups.Rows.FirstOrDefault().Value.ID });
            }

            //foreach (var userGroup in usersGroups.Rows.Values)
            //{
            //    model.Add(new MemberOfGroup(){CreatedBy = userGroup.});
            //}
            
            return PartialView("~/Views/Partials/LoggedIn/Groups/MyGroupsPartial.cshtml", model);
        }

        [CustomSessionAuthorizeFilter]
        public ActionResult ShowGroupFiles(int groupNumber)
        {
            Table<File> groupFiles;
            using (var handler = new PostgreHandler())
            {
                groupFiles = handler.GetEmptyFilesModel();
                groupFiles.SendCustomGetDataQuery(string.Format("select * from \"File\" where \"ID\" in (select \"ID_file\" from \"GroupPermission\" where \"ID_group\" = '{0}')",groupNumber));
            }
            return PartialView("~/Views/Partials/LoggedIn/Files/MyFilesPartial.cshtml", groupFiles);
        }



        //[CustomSessionAuthorizeFilter]
        //public ActionResult UserGroups()
        //{
        //    List<MemberOfGroup> model = new List<MemberOfGroup>();

        //    Table<User> users;
        //    Table<Group> groups;
        //    Table<UserGroup> usersGroups;
        //    using (var handler = new PostgreHandler())
        //    {
        //        groups = handler.GetGroupsModel();
        //        usersGroups = handler.GetUserGroupModel();
        //        users = handler.GetUsersModel();
        //    }
        //    List<UserGroup> temp = new List<UserGroup>();

        //    foreach (var row in usersGroups.Rows)
        //    {
        //        if (row.Value.IDUser == (int)Session["ID"])
        //        {
        //            temp.Add(new UserGroup()
        //            {
        //                ID = row.Value.ID,
        //                IDGroup = row.Value.IDGroup,
        //                IDUser = row.Value.IDGroup
        //            });
        //        }
        //    }

        //    foreach (var row in temp)
        //    {
        //        var info = (from g in groups.Rows where g.Value.ID == row.IDGroup select g).ToArray();
        //        users.SelectWhere(string.Format("\"ID\"='{0}'", row.IDUser));
        //        model.Add(new MemberOfGroup()
        //        {
        //            CreatedOn = info[0].Value.CreatedOn,
        //            Name = info[0].Value.Name,
        //            //CreatedBy = users.Rows[0].Login
        //        });


        //    }


        //    return PartialView("~/Views/Partials/LoggedIn/Groups/MyGroupsPartial.cshtml", model);
        //}


        [CustomSessionAuthorizeFilter]
        public ActionResult Group()
        {
            return PartialView("~/Views/Partials/LoggedIn/Files/GroupDetailsPartial.cshtml");
        }


    }
}