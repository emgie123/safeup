﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SafeUp.Models.DbModels;
using SafeUp.Models.DBPOSTGREs;
using SafeUp.Models.DBPOSTGREs.Interfaces;

namespace SafeUp.Models.SafeUpCollections
{
    public class Files : Table
    {
        public Files(string tableName) : base(tableName)
        {
        }


    }
}