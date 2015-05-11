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
            //PORT=5432;TIMEOUT=15;POOLING=True;MINPOOLSIZE=1;MAXPOOLSIZE=20;COMMANDTIMEOUT=20;COMPATIBLE=2.2.5.0;HOST=safeup.ryuu.me;DATABASE=safeup;USER ID=safeup;PASSWORD=qwerty

          //  PostgreClient client = new PostgreClient("safeup","qwerty","safeup.ryuu.me","safeup");

           // DataSet ds = client.GetData(@"select * from User");


           // var rows = ds.Tables[0].Rows.OfType<DataRow>().Select(x => x.Table.Columns).ToList();

           // var abc = new PostgreSQLClient(new PostgreSqlConnectionData());

        
            //abc.SaveData(new PostgreInsert().InsertStatement(new TestModel()));

            //abc.SaveData(new PostgreSelect().SelectStatement(new TestModel()));

            //abc.SaveData(new PostgreUpdate().UpdateStatement(new TestModel()));

            //abc.SaveData(new PostgreDelete().DeleteStatement(new TestModel()));
            //  DbHandler dbHandler = new DbHandler(new PostgreSQLClient());


          //  object a = 3;
          //  var z = a.GetType();


          //  Type generyczny = typeof (Column<>);
          //  Type jakisTyp = typeof (int);
          //  Type gen = generyczny.MakeGenericType(jakisTyp);
        

  

          //  tbl tab = new tbl("User");
          // // tab.GetAllData();
          //  tab.DeleteRow(10);
          //  tbl tab2 = new tbl("File");
          ////  tab2.GetAllData();

          //  PostgreHandler ac = new PostgreHandler();
          //  var zasad = ac.GetUsersModel();

          //  var passwordByteArray = Encoding.UTF8.GetBytes("asd");

          //  var hash = new SHA512Managed().ComputeHash(passwordByteArray);

          //  var hash2 = Encoding.UTF8.GetString(passwordByteArray);

          //  var hashfinis = Convert.ToBase64String(hash);
          //  zasad.AddRow("raf",hashfinis,"0","1");

            var dict = new Dictionary<int, User>();
            dict.Add(1,new User()
            {
                AccountType = AccountTypeEnum.Free,
                Login = "raf",
                Password = "qwerty",
                UsedSpace = 1000,
                CreatedOn = new DateTime().Date,
                ID = 1
                    

            });

    
            PostgreHandler abc = new PostgreHandler();
            var c= abc.GetUsersModel();

            
        }


     
    }
}
