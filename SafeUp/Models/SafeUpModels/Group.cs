using System;
using SafeUp.Models.DBPOSTGREs;

namespace SafeUp.Models.SafeUpModels 
{
     public class Group //: Row
    {
        public int ID { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; } 
    }
}