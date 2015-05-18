using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SafeUp.Models.DBPOSTGREs;
using SafeUp.Models.SafeUpModels;

namespace SafeUp.Models.ViewModels.Groups
{
    public class MyFilesToAddToGroupViewModel
    {

        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public Table<File> FilesAvailableToAddToGroup { get; set; } 
        public Table<File> FilesToRemoveFromGroup { get; set; } 
    }
}