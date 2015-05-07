using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SafeUp.Models.DbModels;
using SafeUp.Models.DBPOSTGREs;

namespace SafeUp.Models.SafeUpCollections
{
    public class Files : Table
    {
        public Dictionary<int, File> Rows { get; set; }
    }
}