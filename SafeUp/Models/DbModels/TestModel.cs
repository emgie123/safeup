using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SafeUp.Models.DBAL.Interfaces;
using SafeUp.Models.DBAL.Abstraction;

namespace SafeUp.Models.DbModels
{
    public class TestModel : Table
    {

        public TestModel()
        {
            this.TableName = "test";
            this.Row.Add("id", new Column<object>("id", 1));
            this.Row.Add("nazwa", new Column<object>("nazwa", "sdas"));
        }

 

    }
}