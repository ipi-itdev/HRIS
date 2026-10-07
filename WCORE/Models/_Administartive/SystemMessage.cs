using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    public class SystemMessage 
    {
        public string Message { get; set; }
        public bool Status { get; set; }
    }
}