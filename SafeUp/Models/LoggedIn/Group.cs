using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafeUp.Models.LoggedIn
{
    public class Group
    {
        public string Name { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public string CreatedBy { get; private set; }
        public List<User> Admins { get; private set; }
        public List<File> GroupFiles { get; private set; }

    }
}