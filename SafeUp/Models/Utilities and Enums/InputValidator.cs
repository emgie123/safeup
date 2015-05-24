using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Security.Application;

namespace SafeUp.Models.Utilities_and_Enums
{
    public static class InputValidator
    {

        public static string  ValidateInputAttribute(string input)
        {
            input = Sanitizer.GetSafeHtmlFragment(input);
            input= input.Replace("'", "").Replace(";", "").Replace("--", "").Replace("=", "").Replace(" ","");



            return input;
        }

    }
}