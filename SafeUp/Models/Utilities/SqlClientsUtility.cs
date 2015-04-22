using System;
using System.Collections.Generic;

namespace SafeUp.Models.Utilities
{
    public static class SqlClientsUtility
    {
       public static Dictionary<int,string> GetPostgreIDBConnectionData = new Dictionary<int, string>

            {
                {1,"localhost"},
                {2,"5432"},
                {3,"postgres"},
                {4,"postgre"},
                {5,"qwerty"},
            };

        //Server,
        //Port,
        //Database,
        //UserId,
        //Password
    }

}

