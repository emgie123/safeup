using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafeUp.Models.LoggedIn
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public float UsedSpace { get; set; }
        public AccountType.AccountTypeEnum AccountType { get; set; }
        public List<UserGroup> UserGroups { get; set; }
        public List<File> UserFiles { get; set; }





    }
}