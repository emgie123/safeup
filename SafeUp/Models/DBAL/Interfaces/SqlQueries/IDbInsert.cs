using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafeUp.Models.DBAL.Interfaces.SqlQueries
{
    public interface IDbInsert
    {
        string InsertStatement(ITable table);
    }
}