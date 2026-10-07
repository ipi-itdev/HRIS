using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "Performance Indicator")]
    [DatabaseTable(Name = "dbo.fPerformanceIndicatorSelect(@User)", ViewName = "dbo.fPerformanceIndicatorSelect(@User)", PKeyName = "ID")]
    public class PerformanceIndicatorSelect : BaseObject
    {
        [DetailViewItem(IsTextArea = true)]
        [DatabaseField(IsRequired = true, IsUnique = true)]
        [ListViewColumn(Width = 150)]
        public string Description { get; set; }
    }
}