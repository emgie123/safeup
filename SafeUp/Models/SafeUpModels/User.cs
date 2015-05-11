using System;
using SafeUp.Models.DBPOSTGREs;
using SafeUp.Models.Utilities_and_Enums;

namespace SafeUp.Models.SafeUpModels
{
     public class User : Row
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; }
        public float UsedSpace { get; set; } 
        public AccountTypeEnum AccountType { get; set; } 
    }
}