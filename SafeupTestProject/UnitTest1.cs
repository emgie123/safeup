using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SafeUp.Models.DB;
using SafeUp.Models.DBPOSTGREs;
using SafeUp.Models.SafeUpCollections;
using SafeUp.Models.SafeUpModels;
using SafeUp.Models.SSLConnection;
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
           // var c= abc.GetUsersModel();

           // c.AddRow(new User() { UsedSpace = 0, Login = "raf", AccountType = AccountTypeEnum.Free, CreatedOn = new DateTime().Date, Password = "DdPlEmQsl8o/dH+aduN0+9pz+SkoI8AxO+nXit183Y9yI1rwxVPdJnl+eOGFTt7grgAviroHSwZt/OGvEU4y+A=="});
        
            SelectWhere("id=3 and name=halina");
            List<int> abcd = new List<int>();
            abcd.Add(1);
            abcd.Add(2);
            abcd.Add(3);
            abcd.Add(4);
            abcd.Add(5);

            var passwordAsByteArray = Encoding.UTF8.GetBytes("qwerty");
            var hashAsByteArray = new SHA512Managed().ComputeHash(passwordAsByteArray);

            var hash = Convert.ToBase64String(hashAsByteArray);

            
        }

        public void SelectWhere(string whereClause)
        {
 
            var splittedClause = whereClause.Split(new[] {"and"}, StringSplitOptions.RemoveEmptyEntries);
            string output = string.Empty;


            int lastIndex = splittedClause.Count();

            for (int i = 0; i < lastIndex; i++)
            {
                var elements =  splittedClause[i].Replace(" ", "").Split('=');

                output += string.Format("\"{0}\"='{1}'", elements[0], elements[1]);
                if (i + 1 != lastIndex) output += " and ";
                
            }

        
           // string customQuery = string.Format("{0} where {1}", SelectQuery, whereClause);
       
        }

        [TestMethod]
        public void TestSslConnection()
        {
            SslClient client = new SslClient();
            client.nothing();
            client.DownloadSslCertificate("safeup.ryuu.me");

         
        }

     
    }
}
