using System.Collections.Generic;

namespace SafeUp.Models.DBPOSTGREs.Interfaces
{
    public interface ITable
    {
        Dictionary<int, IRow> Rows { get; set; }

    }
}