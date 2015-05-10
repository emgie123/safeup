﻿using SafeUp.Models.DBPOSTGREs;

namespace SafeUp.Models.SafeUpModels
{
     public class AccountType : Row
    {
        public Column<int> ID { get; set; }
        public Column<string> Name { get; set; }
        public Column<float> DiskSpace { get; set; } 
    }
}