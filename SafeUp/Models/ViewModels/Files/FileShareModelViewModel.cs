using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SafeUp.Models.SafeUpModels;

namespace SafeUp.Models.ViewModels.Files
{
    public class FileShareModelViewModel
    {
        public List<Group> GroupsList { get; set; }
        public List<User> UserList { get; set; }  
        public string UserName { get; set; }
        public int IdFile { get; set; }
        public List<bool> FileAddedToGroup { get; set; }
        public string ReturnMessage { get; set; }
         
 
        public FileShareModelViewModel()
        {
            GroupsList = new List<Group>();
            UserList = new List<User>();
            FileAddedToGroup = new List<bool>();
        }
    }
}