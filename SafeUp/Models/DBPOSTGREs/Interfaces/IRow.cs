using System.Collections.Generic;

namespace SafeUp.Models.DBPOSTGREs.Interfaces
{
    public interface IRow
    {
        int RowId { get; set; }
        Dictionary<string,IColumn<object>> Columns { get; set; } 
    }
}
