using System;
using SafeUp.Models.DBPOSTGREs;
using SafeUp.Models.DBPOSTGREs.Interfaces;

namespace SafeUp.Models.DbModels
{
    public class User : Row
    {
        public Column<string> Login { get; set; }
        public Column<string> Password { get; set; }
        public Column<DateTime> CreatedOn { get; set; }
        public Column<AccountType> AccountType { get; set; } 
    }
}