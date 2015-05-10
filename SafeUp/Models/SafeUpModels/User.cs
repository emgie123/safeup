using System;
using SafeUp.Models.DBPOSTGREs;

namespace SafeUp.Models.SafeUpModels
{
     public class User : Row
    {
        public Column<int> ID { get; set; }
        public Column<string> Login { get; set; }
        public Column<string> Password { get; set; }
        public Column<DateTime> CreatedOn { get; set; }
        public Column<float> UsedSpace { get; set; } 
        public Column<AccountType> AccountType { get; set; } 
    }
}