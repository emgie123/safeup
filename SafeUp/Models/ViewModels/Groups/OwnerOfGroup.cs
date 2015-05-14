using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafeUp.Models.ViewModels.Groups
{
    public class OwnerOfGroup
    {
        public string Name;
        public DateTime CreatedOn { get; set; }
        public int ID { get; set; }  // potrzebuję ID by później dalej operować na grupach
     
    }
}