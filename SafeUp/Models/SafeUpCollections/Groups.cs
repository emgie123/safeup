using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SafeUp.Models.DbModels;
using SafeUp.Models.DBPOSTGREs;

namespace SafeUp.Models.SafeUpCollections
{
    public class Groups : Table
    {
        public Dictionary<int, Group> Rows { get; set; } 
    }
}