using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafeUp.Models.LoggedIn
{
    public class File
    {
        public string Name { get; private set; }
        public DateTime DateOfUpload { get; private set; }
        public string Owner { get; private set; }

        public bool IsChecked { get; set; }

        public File(string name, DateTime dateOfUpload, string owner)
        {
            this.Name = name;
            this.DateOfUpload = dateOfUpload;
            this.Owner = owner;
        }
       
    }
}