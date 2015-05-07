using System.Collections.Generic;
using SafeUp.Models.DBPOSTGREs;
using SafeUp.Models.DBPOSTGREs.Interfaces;

namespace SafeUp.Models.DbCollections
{
    public class Users : Table
    {
        public Users(string tableName) : base(tableName)
        {
        }

    }
}