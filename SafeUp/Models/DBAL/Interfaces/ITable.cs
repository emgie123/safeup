using System.Collections.Generic;

namespace SafeUp.Models.DBAL.Interfaces
{
    public interface ITable
    {
        string TableName { get; }
        Dictionary<string, IColumn<object>> Row { get; }
    }
}