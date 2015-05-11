using System;
using SafeUp.Models.SafeUpCollections;
using SafeUp.Models.SafeUpModels;

namespace SafeUp.Models.DBPOSTGREs
{
    public class PostgreHandler : IDisposable
    {
        public Table<AccountType> GetAccountTypesModel()
        {
            return new AccountTypes();
        }

        public Table<File> GetFilesModel()
        {
            return new Files();
        }

        public Table<GroupPermission> GetGroupPermissionsModel()
        {
            return new GroupPermissions();
        }

        public Table<Group> GetGroupsModel()
        {
            return new Groups();
        }

        public Table<Permission> GetPermissionsModel()
        {
            return new Permissions();
        }

        public Table<UserGroup> GetUserGroupModel()
        {
            return new UserGroups();
        }

        public Table<User> GetUsersModel()
        {
            return new Users();
        }

        public void Dispose()
        {

            GC.SuppressFinalize(this);
        }
    }
}