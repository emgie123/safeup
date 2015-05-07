using System.Collections.Generic;

namespace SafeUp.Models.DBPOSTGREs.Interfaces
{
    public interface IRow
    {
        int RowId { get; set; }
        List<IColumn<object>> Columns { get; set; } 
    }
}
