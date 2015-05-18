using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafeUp.Models.ViewModels.Groups
{
    public class AllUserGroupsViewModel
    {
        public AllUserGroupsViewModel()
        {
            MemberedGroups = new List<MemberOfGroup>();
            OwnedGroups = new List<OwnerOfGroupViewModel>();
        }

        public List<MemberOfGroup> MemberedGroups;
        public List<OwnerOfGroupViewModel> OwnedGroups;

       
    }
}