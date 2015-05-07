using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SafeUp.Models.DbModels;
using SafeUp.Models.DBPOSTGREs.Interfaces;

namespace SafeUp.Models.DBPOSTGREs.Factories
{
    public class ModelFactory
    {
        public IRow GetProperModel(string tableName)
        {
            Dictionary<string, Func<IRow>> modelsDictionary = new Dictionary<string, Func<IRow>>()
            {
                {"AccountType", ()=>new AccountType()},
                {"File", ()=>new File()},
                {"GroupPermission", ()=> new GroupPermission()},
                {"Group", ()=> new Group()},
                {"Permission", ()=>new Permission()},
                {"UserGroup", ()=> new UserGroup()},
                {"User", ()=> new User()}
            };
            return modelsDictionary[tableName]();
        }
    }
}