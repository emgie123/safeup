using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafeUp.Models.ViewModels.SharedFiles
{
    public class AllUserSharedFiles
    {

        public AllUserSharedFiles()
        {
            SharedFilesToGroup= new List<SharedFilesToGroup>();
            SharedFilesToUser = new List<SharedFilesToUser>();
        }
        public List<SharedFilesToUser> SharedFilesToUser { get; set; }
        public List<SharedFilesToGroup> SharedFilesToGroup { get; set; }
    }
}