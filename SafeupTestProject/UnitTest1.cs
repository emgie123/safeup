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
       
            PostgreHandler abc = new PostgreHandler();
            var c= abc.GetUsersModel();
            

            
        }


     
    }
}
