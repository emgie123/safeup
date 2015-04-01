using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafeUp.Models.LoggedIn
{
    public class UserGroup
    {
        public DateTime CreatedOn { get; set; }
        public User CreatedBy { get; set; }
        public string GroupName { get; set; }
        public List<User> AdminsList { get; set; }
        public List<File> GroupFiles { get; set; }

    }
}