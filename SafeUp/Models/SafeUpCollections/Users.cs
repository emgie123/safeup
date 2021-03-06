﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using SafeUp.Models.DBPOSTGREs;
using SafeUp.Models.DBPOSTGREs.Interfaces;
using SafeUp.Models.SafeUpModels;

namespace SafeUp.Models.SafeUpCollections
{
    internal class Users : Table<User>
    {

        public override sealed Dictionary<int, User> Rows { get; set; }

        public Users(bool fillModel,string tableName = "User") : base(tableName)
        {
            SelectQuery = string.Format("select * from \"{0}\"", TableName);
            Rows = new Dictionary<int, User>();
            if(fillModel) FillModelWithAllData();
        }

        protected override User GetRowModelInstance(int id)
        {
            return new User(){ID = id};
        }

        public override void AddRow(User detailRowModel)
        {
            //if(Rows[detailRowModel.ID].Login == detailRowModel.Login) throw new Exception("Login już istnieje!");

            InsertQuery = string.Format("insert into \"User\" values (default,'{0}','{1}','{2}','{3}')", detailRowModel.Login,
            detailRowModel.Password, detailRowModel.UsedSpace, (int)detailRowModel.AccountType);
            PostgreClient.SetData(InsertQuery);
            
            base.AddRow(detailRowModel);

            
        }

    }
}