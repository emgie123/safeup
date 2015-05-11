
using SafeUp.Models.DBPOSTGREs;

namespace SafeUp.Models.SafeUpModels
{
     public class Permission //: Row
    {
        public int ID { get; set; }
        public int IdUser { get; set; }
        public int IdFile { get; set; } 
    }
}