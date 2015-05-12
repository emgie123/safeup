using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafeUp.Models.ViewModels.Groups
{
    public class AllUserGroups
    {
        public AllUserGroups()
        {
            MemberedGroups = new List<MemberOfGroup>();
            OwnedGroups = new List<OwnerOfGroup>();
        }

        public List<MemberOfGroup> MemberedGroups;
        public List<OwnerOfGroup> OwnedGroups;

       
    }
}