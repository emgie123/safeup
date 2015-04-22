using System.Collections.Generic;

namespace SafeUp.Models.DBAL.Interfaces
{
    public interface IDbConnectionData
    {
         Dictionary<int,string> ConnectionData { get; } 
    }
}