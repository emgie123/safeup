﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafeUp.Models.ViewModels.SharedFiles
{
    public class SharedFilesToUserViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public double Size { get; set; }
        public string Owner { get; set; }
    }
}