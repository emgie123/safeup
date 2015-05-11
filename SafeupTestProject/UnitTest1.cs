using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SafeUp.Models.DBPOSTGREs;
using SafeUp.Models.SafeUpCollections;
using SafeUp.Models.SafeUpModels;
using SafeUp.Models.Utilities_and_Enums;


namespace SafeupTestProject
{
    [TestClass]
    public class UnitTest1 
    {
        [TestMethod]
        public void TestMethod1()
        {
       
            //qwerty
            //DdPlEmQsl8o/dH+aduN0+9pz+SkoI8AxO+nXit183Y9yI1rwxVPdJnl+eOGFTt7grgAviroHSwZt/OGvEU4y+A==
            PostgreHandler abc = new PostgreHandler();
            var c= abc.GetUsersModel();

            c.AddRow(new User() { UsedSpace = 0, Login = "raf", AccountType = AccountTypeEnum.Free, CreatedOn = new DateTime().Date, Password = "DdPlEmQsl8o/dH+aduN0+9pz+SkoI8AxO+nXit183Y9yI1rwxVPdJnl+eOGFTt7grgAviroHSwZt/OGvEU4y+A=="});

            var passwordAsByteArray = Encoding.UTF8.GetBytes("qwerty");
            var hashAsByteArray = new SHA512Managed().ComputeHash(passwordAsByteArray);

            var hash = Convert.ToBase64String(hashAsByteArray);

            
        }


     
    }
}
