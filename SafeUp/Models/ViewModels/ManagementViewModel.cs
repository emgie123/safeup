using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SafeUp.Models.DBPOSTGREs;
using SafeUp.Models.SafeUpModels;

namespace SafeUp.Models.ViewModels
{
    public class ManagementViewModel
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string Message { get; set; }

        public Table<User> UsersList { get; set; }

    }
}