using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SafeUp.Models.SafeUpModels;

namespace SafeUp.Models.ViewModels.Files
{
    public class FileShareModel
    {
        public List<Group> GroupsList { get; set; }
        public string UserName { get; set; }
        public int IdFile { get; set; }
        public List<bool> FileAddedToGroup { get; set; }
 
        public FileShareModel()
        {
            GroupsList = new List<Group>();
            FileAddedToGroup = new List<bool>();
        }
    }
}