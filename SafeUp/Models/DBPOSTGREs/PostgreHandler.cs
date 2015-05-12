using System;
using SafeUp.Models.SafeUpCollections;
using SafeUp.Models.SafeUpModels;

namespace SafeUp.Models.DBPOSTGREs
{
    public class PostgreHandler : IDisposable
    {
        public Table<AccountType> GetEmptyAccountTypesModel()
        {
            return new AccountTypes(false);
        }

        public Table<File> GetEmptyFilesModel()
        {
            return new Files(false);
        }

        public Table<GroupPermission> GetEmptyGroupPermissionsModel()
        {
            return new GroupPermissions(false);
        }

        public Table<Group> GetEmptyGroupsModel()
        {
            return new Groups(false);
        }

        public Table<Permission> GetEmptyPermissionsModel()
        {
            return new Permissions(false);
        }

        public Table<UserGroup> GetEmptyUserGroupModel()
        {
            return new UserGroups(false);
        }

        public Table<User> GetEmptyUsersModel()
        {
            return new Users(false);
        }

        //================================================================================
        public Table<AccountType> GetFilledAccountTypesModel()
        {
            return new AccountTypes(true);
        }

        public Table<File> GetFilledFilesModel()
        {
            return new Files(true);
        }

        public Table<GroupPermission> GetFilledGroupPermissionsModel()
        {
            return new GroupPermissions(true);
        }

        public Table<Group> GetFilledGroupsModel()
        {
            return new Groups(true);
        }

        public Table<Permission> GetFilledPermissionsModel()
        {
            return new Permissions(true);
        }

        public Table<UserGroup> GetFilledUserGroupModel()
        {
            return new UserGroups(true);
        }

        public Table<User> GetFilledUsersModel()
        {
            return new Users(true);
        }


        public void Dispose()
        {

            GC.SuppressFinalize(this);
        }
    }
}