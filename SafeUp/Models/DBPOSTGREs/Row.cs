using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SafeUp.Models.DBPOSTGREs.Interfaces;

namespace SafeUp.Models.DBPOSTGREs
{
    public class Row : IRow
    {
        public int RowId { get; set; }
        public Dictionary<string, IColumn<object>> Columns { get; set; }

        public Row()
        {
            Columns = new Dictionary<string, IColumn<object>>();
        }
    }
}