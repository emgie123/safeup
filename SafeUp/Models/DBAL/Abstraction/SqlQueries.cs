using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SafeUp.Models.DBAL.Enums;

namespace SafeUp.Models.DBAL.Abstraction
{
    public abstract class SqlQueries
    {
        protected const string ColumnDelimiter = ",";
        protected const string AndOperator = " AND ";
        protected const string EqualOperator = "=";

        protected string _pattern;

        protected Dictionary<Type, string> Surroundings = new Dictionary<Type, string>()
        {
            {typeof(int), ""},
            {typeof(string), "'"},
            {typeof(double), ""},
            {typeof(DateTime), "'"}
        };

        protected Dictionary<SelectClause, string> Signs = new Dictionary<SelectClause, string>()
        {
            {SelectClause.Equal, "="},
            {SelectClause.Like, "LIKE"},
            {SelectClause.NotEqual, "!="}
        };  

        protected string GetClausuleSign(SelectClause clause)
        {
            return string.Format("{0}", Signs[(clause)]);
        }

        protected string GetSurroundedValue<T>(T value)
        {
            return string.Format("{0}{1}{0}",
                Surroundings.ContainsKey(value.GetType()) ? Surroundings[value.GetType()] : "'", value);
        }
    }
}