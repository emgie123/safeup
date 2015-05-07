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
        public List<IColumn<object>> Columns { get; set; }
    }
}