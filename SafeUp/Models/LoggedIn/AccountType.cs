using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafeUp.Models.LoggedIn
{
    public static class AccountType
    {
        public enum AccountTypeEnum
        {
            Free,
            Silver,
            Gold,
            Platinum
        };
    }
}