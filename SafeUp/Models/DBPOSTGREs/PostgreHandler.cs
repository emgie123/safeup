using System;
using SafeUp.Models.SafeUpCollections;

namespace SafeUp.Models.DBPOSTGREs
{
    public class PostgreHandler : IDisposable
    {
        public Table GetAccountTypesModel()
        {
            return new AccountTypes();
        }

        public Table GetFilesModel()
        {
            return new Files();
        }

        public Table GetGroupPermissionsModel()
        {
            return new GroupPermissions();
        }

        public Table GetGroupsModel()
        {
            return new Groups();
        }

        public Table GetPermissionsModel()
        {
            return new Permissions();
        }

        public Table GetUserGroupModel()
        {
            return new UserGroups();
        }

        public Table GetUsersModel()
        {
            return new SafeUpCollections.Users();
        }

        public void Dispose()
        {

            GC.SuppressFinalize(this);
        }
    }
}