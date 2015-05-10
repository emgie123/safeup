
using SafeUp.Models.DBPOSTGREs;

namespace SafeUp.Models.SafeUpModels
{
     class Permission : Row
    {
        public Column<int> ID { get; set; }
        public Column<int> IdUser { get; set; }
        public Column<int> IdFile { get; set; } 
    }
}