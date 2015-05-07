using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SafeUp.Models.DbModels;
using SafeUp.Models.DBPOSTGREs;
using SafeUp.Models.DBPOSTGREs.Interfaces;

namespace SafeUp.Models.SafeUpCollections
{
    public class AccountTypes : Table
    {
        public AccountTypes(string tableName) : base(tableName)
        {
        }

        public override Dictionary<int, IRow> Rows { get; set; }
    }
}