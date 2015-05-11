using System;
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
    public class Users : Table<User>
    {

        public override sealed Dictionary<int, User> Rows { get; set; }

        public Users(string tableName = "User") : base(tableName)
        {

            Rows = new Dictionary<int, User>();
        }

        public override void AddRow(User detailRowModel)
        {
            InsertQuery = string.Format("insert into \"User\" values (default,'{0}','{1}','{2}','{3}'", detailRowModel.Login,
                detailRowModel.Password, detailRowModel.UsedSpace, detailRowModel.AccountType);
            PostgreClient.SetData(InsertQuery);

        }

        public void abc()
        {
            FillModelWithData();
        }


        protected override void FillModelWithData()
        {
            Rows.Clear();
            SelectQuery = string.Format("select * from \"{0}\"", TableName);
            DataSet ds = PostgreClient.GetData(SelectQuery);
            bool addNewRow = true;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                var rowID = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);
                Rows.Add(rowID, new User());

                for (int j = 0; j < ds.Tables[0].Rows[i].ItemArray.Count(); j++)
                {
                    
                    var columnValue = ds.Tables[0].Rows[i].ItemArray[j];
                    var columnName =  string.Format("<{0}>k__BackingField",ds.Tables[0].Columns[j]);

                    //todo tutaj jakaś flaga która zczyta tez zmienną ID która jest w TABLE a nie w konklretnej tabeli (bo teraz w user 
                    // "przykryłem" tą zmienna taką samą o tej samej nazwie to ją widzi. potestuj

                    FieldInfo field = Rows[rowID].GetType().GetField(columnName, BindingFlags.Instance | BindingFlags.NonPublic);
    
                    field.SetValue(Rows[rowID], columnValue);

                }
            }

        }


        public override void SendCustomQuery(string query)
        {
            throw new System.NotImplementedException();
        }

    }
}