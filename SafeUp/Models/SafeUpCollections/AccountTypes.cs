using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SafeUp.Models.DBPOSTGREs;
using SafeUp.Models.DBPOSTGREs.Interfaces;

namespace SafeUp.Models.SafeUpCollections
{
     class AccountTypes : Table
    {
        public AccountTypes(string tableName="AccountType") : base(tableName)
        {
        }


    }
}