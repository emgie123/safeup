using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SafeUp.Models.SafeUpModels;

namespace SafeUp.Models.ViewModels.Groups
{
    public class AllGroupFiles
    {
        public string GroupName { get; set; }
        public List<File> FileList { get; set; }

        public AllGroupFiles()
        {
            FileList = new List<File>();
        }
    }
}