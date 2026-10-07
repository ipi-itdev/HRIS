using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "Evaluation Purpose")]
    [DatabaseTable(Name = "dbo.PIS_EvalPurpose", PKeyName = "ID")]
    public class EvaluationPurpose : BaseObject
    {
        [Display(Name = "Purpose")]
        [ListViewColumn]
        [DatabaseField(IsRequired = true)]
        public string Description { get; set; }
    }
}