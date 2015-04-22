using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafeUp.Models.DBAL.Abstraction
{
    public abstract class SqlQueries
    {
        protected const string _columnDelimiter = ",";
        protected string _pattern;

        protected Dictionary<Type, string> Surroundings = new Dictionary<Type, string>()
        {
            {typeof(int), ""},
            {typeof(string), "'"},
            {typeof(double), ""},
            {typeof(DateTime), "'"}
        };
    }
}