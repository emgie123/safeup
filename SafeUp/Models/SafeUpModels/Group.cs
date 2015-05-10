﻿using System;
using SafeUp.Models.DBPOSTGREs;

namespace SafeUp.Models.SafeUpModels 
{
     public class Group : Row
    {
        public Column<int> ID { get; set; }
        public Column<DateTime> CreatedOn { get; set; }
        public Column<int> CreatedBy { get; set; } 
    }
}