using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SafeUp.Models.DBPOSTGREs;
using SafeUp.Models.DBPOSTGREs.Interfaces;

namespace SafeUp.Models.SafeUpCollections
{
     class Permissions : Table
    {
         public Permissions(string tableName = "Permission")
             : base(tableName)
        {
        }

    }
}