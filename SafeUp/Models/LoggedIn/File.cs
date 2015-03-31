using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafeUp.Models.LoggedIn
{
    public class File
    {
        public string Name { get; private set; }
        public bool IsChecked { get; set; }

        public File(string name)
        {
            this.Name = name;
        }
       
    }
}