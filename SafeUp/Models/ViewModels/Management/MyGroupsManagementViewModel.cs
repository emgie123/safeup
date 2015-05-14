using System.Collections.Generic;
using SafeUp.Models.ViewModels.Groups;

namespace SafeUp.Models.ViewModels.Management
{
    public class MyGroupsManagementViewModel
    {


        public MyGroupsManagementViewModel()
        {
            MyGroups = new List<OwnerOfGroup>();
        }

        public List<OwnerOfGroup> MyGroups;
        public string Message { get; set; }
    }
}