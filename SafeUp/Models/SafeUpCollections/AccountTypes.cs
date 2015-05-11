﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SafeUp.Models.DBPOSTGREs;
using SafeUp.Models.DBPOSTGREs.Interfaces;
using SafeUp.Models.SafeUpModels;

namespace SafeUp.Models.SafeUpCollections
{
    public class AccountTypes : Table<AccountType>
    {
        public AccountTypes(string tableName="AccountType") : base(tableName)
        {
            Rows = new Dictionary<int, AccountType>();
            FillModelWithData();

        }

        public override Dictionary<int, AccountType> Rows { get; set; }


        protected override AccountType GetInstance()
        {
          return new AccountType();
        }

        public override void AddRow(AccountType detailRowModel)
        {
            InsertQuery = string.Format(
                "insert into \"User\" values (default,'{0}','{1}'", detailRowModel.Name, detailRowModel.DiskSpace);

            PostgreClient.SetData(InsertQuery);
        }

    
    }
}