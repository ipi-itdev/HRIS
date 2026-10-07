using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "%^ Weight")]
    [DatabaseTable(Name = "dbo.PerformancePercentage", PKeyName = "ID")]
    public class PerformancePercentage : BaseObject
    {
        [DatabaseField(IsRequired = true)]
        public string Description { get; set; }
    }
}