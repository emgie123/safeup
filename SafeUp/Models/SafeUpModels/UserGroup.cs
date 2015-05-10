

using SafeUp.Models.DBPOSTGREs;

namespace SafeUp.Models.SafeUpModels
{
     public class UserGroup : Row
    {
        public Column<int> ID { get; set; }
        public Column<int> IdGroup { get; set; }
        public Column<int> IdUser { get; set; }
        public Column<bool> IsAdmin { get; set; }
    }
}