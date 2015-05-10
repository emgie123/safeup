using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SafeUp.Models.DBPOSTGREs.Interfaces;
using SafeUp.Models.SafeUpModels;

namespace SafeUp.Models.DBPOSTGREs.Factories
{
    public class ModelFactory
    {
        public IRow GetProperModel(string tableName)
        {
            Dictionary<string, Func<IRow>> modelsDictionary = new Dictionary<string, Func<IRow>>()
            {
                {"ACCOUNTTYPE", ()=>new AccountType()},
                {"FILE", ()=>new File()},
                {"GROUPPERMISSION", ()=> new GroupPermission()},
                {"GROUP", ()=> new Group()},
                {"PERMISSION", ()=>new Permission()},
                {"USERGROUP", ()=> new UserGroup()},
                {"USER", ()=> new User()}
            };
            return modelsDictionary[tableName]();
        }
    }
}