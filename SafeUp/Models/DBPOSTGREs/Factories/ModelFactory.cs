using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SafeUp.Models.DBPOSTGREs.Interfaces;
using SafeUp.Models.SafeUpModels;

namespace SafeUp.Models.DBPOSTGREs.Factories
{
    public static class ModelFactory
    {

        public static Dictionary<string, Func<object>> modelsDictionary = new Dictionary<string, Func<object>>
        {
            {"ACCOUNTTYPE", () => new AccountType()},
            {"FILE", () => new File()},
            {"GROUPPERMISSION", () => new GroupPermission()},
            {"GROUP", () => new Group()},
            {"PERMISSION", () => new Permission()},
            {"USERGROUP", () => new UserGroup()},
            {"USER", () => new User()}
        };



    }
}