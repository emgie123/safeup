using System;
using SafeUp.Models.DBPOSTGREs;

namespace SafeUp.Models.SafeUpModels
{
     public class File //: Row
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public int Owner { get; set; }
        public DateTime CreatedOn { get; set; }
        public double Size { get; set; }
        public string Key { get; set; } 
    }
}