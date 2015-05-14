using SafeUp.Models.DBPOSTGREs;
using SafeUp.Models.SafeUpModels;

namespace SafeUp.Models.ViewModels.Management
{
    public class SpecificGroupManagementViewModel
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string Message { get; set; }

        public Table<User> UsersList { get; set; }

    }
}