﻿using System;
using SafeUp.Models.DBPOSTGREs;

namespace SafeUp.Models.SafeUpModels
{
     public class File : Row
    {
        public Column<int> ID { get; set; }
        public Column<string> Name { get; set; }
        public Column<string> Path { get; set; }
        public Column<int> Owner { get; set; }
        public Column<DateTime> CreatedOn { get; set; }
        public Column<double> Size { get; set; }
        public Column<string> Key { get; set; } 
    }
}