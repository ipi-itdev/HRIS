using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "Malayan Coverage")]
    [DatabaseTable(Name = "GEN_MalayanCoverage_M", PKeyName = "MalayanCoverageRefNo")]
    public class MaxicareCoverage : BaseObject
    {
        [DetailViewItem]
        [DatabaseField(IsRequired = true, IsUnique = true)]
        [ListViewColumn]
        public string Description { get; set; }
    }
}