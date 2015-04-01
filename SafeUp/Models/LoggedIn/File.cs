using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafeUp.Models.LoggedIn
{
    public class File
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Owner { get; set; }
        public DateTime DateOfUpload { get; set; }
        public float Size { get; set; }



    }
}