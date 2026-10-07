using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WCORE.Utility;

namespace WCORE.Models
{
    [DatabaseTable(Name = "ScorecardPercentage",PKeyName = "ID")]
    public class KPIScoreCard : BaseObject
    {
        [Display(Name = "Scorecard")]
        [DatabaseField(IsRequired = true)]
        [ListViewColumn]
        [DetailViewItem(IsTextArea = true)]
        public string Description { get; set; }
    }
}