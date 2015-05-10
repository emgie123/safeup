
using SafeUp.Models.DBPOSTGREs;

namespace SafeUp.Models.SafeUpModels
{
     public class GroupPermission : Row
    {
        public Column<int> ID { get; set; }
        public Column<int> IdFile { get; set; }
        public Column<int> IdGroup { get; set; }
    }
}