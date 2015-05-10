using System;
using System.Collections.Generic;

namespace SafeUp.Models.Utilities
{
    public static class SqlClientsUtility
    {
       public static Dictionary<int,string> GetPostgreIDBConnectionData = new Dictionary<int, string>

            {
                {0,"localhost"},
                {1,"5432"},
                {2,"postgres"},
                {3,"postgres"},
                {4,"qwerty"},
            };

        //Server,
        //Port,
        //Database,
        //UserId,
        //Password
    }

}

