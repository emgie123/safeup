using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeUp.Models.DBAL.Interfaces.SqlQueries
{
    public interface IDbSelect
    {

        string SelectStatement(ITable table);

    }
}
