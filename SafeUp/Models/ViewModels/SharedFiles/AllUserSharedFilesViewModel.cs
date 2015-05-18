using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafeUp.Models.ViewModels.SharedFiles
{
    public class AllUserSharedFilesViewModel
    {

        public AllUserSharedFilesViewModel()
        {
            SharedFilesToGroup= new List<SharedFilesToGroupViewModel>();
            SharedFilesToUser = new List<SharedFilesToUserViewModel>();
        }
        public List<SharedFilesToUserViewModel> SharedFilesToUser { get; set; }
        public List<SharedFilesToGroupViewModel> SharedFilesToGroup { get; set; }
    }
}