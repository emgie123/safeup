
using SafeUp.Models.DBPOSTGREs;

namespace SafeUp.Models.SafeUpModels
{
     public class Permission //: Row
    {
        public int ID { get; set; }
        public int IDUser { get; set; }
        public int IDFile { get; set; } 
    }
}