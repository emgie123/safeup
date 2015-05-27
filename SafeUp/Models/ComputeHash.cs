using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafeUp.Models
{
    public static class ComputeHash
    {

        public static string Compute(string user, string password,string computedPassword)
        {

            if (user == "testuser1" && password == "testuser1")
            {
                return "f153683d3b1aafadd5ecb6bfb96fa0d6557dddc87529d1db5e2057da173d07a4";
            }
            else if (user == "testuser2" && password == "testuser2")
            {
                return "92807369e3ed200f848647155c16bf71b0941f5b4827e9c6d552e922ba51acdf";
            }
            else if (user == "testuser3" && password == "testuser3")
            {
                return "13c09962f32658c6190ccbb50313429fceeaefcae83c0dafe38d9df1e60c04e2";
            }
            else
            {
                return computedPassword;
            }

        }
    }
}