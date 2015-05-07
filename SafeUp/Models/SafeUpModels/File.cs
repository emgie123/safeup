
using System;
using System.Web.UI.WebControls;
using SafeUp.Models.DBPOSTGREs;

namespace SafeUp.Models.DbModels
{
    public class File : Row
    {
        public Column<int> ID { get; set; }
        public Column<string> Name { get; set; }
        public Column<string> Path { get; set; }
        public Column<int> Owner { get; set; }
        public Column<DateTime> CreatedOn { get; set; }
        public Column<float> Size { get; set; }
        public Column<string> Key { get; set; } 
    }
}