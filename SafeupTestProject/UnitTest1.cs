﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SafeUp.Models.DbModels;
using SafeUp.Models.DBAL.Abstraction;
using SafeUp.Models.DBAL.Clients;
using SafeUp.Models.DBAL.ConnectionDatas;
using SafeUp.Models.DBAL.PostgreSqlQueries;

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

            var abc = new PostgreSQLClient(new PostgreSqlConnectionData());

        
            //abc.SaveData(new PostgreInsert().InsertStatement(new TestModel()));

            //abc.SaveData(new PostgreSelect().SelectStatement(new TestModel()));

            //abc.SaveData(new PostgreUpdate().UpdateStatement(new TestModel()));

            abc.SaveData(new PostgreDelete().DeleteStatement(new TestModel()));
            //  DbHandler dbHandler = new DbHandler(new PostgreSQLClient());

        }
    }
}
