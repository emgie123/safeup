using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SafeUp.Models.DB
{
    public interface IDbClient
    {
        int SetData(string queryString);
        DataSet GetData(string queryString);

    }
}