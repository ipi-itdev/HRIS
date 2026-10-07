using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "Job Band")]
    [DatabaseTable(Name = "PIS_JobBand_U", PKeyName = "JobBandRefNo")]
    public class JobBand : BaseObject
    {
        [DetailViewItem(IsTextArea = true)]
        [DatabaseField(IsRequired = true, IsUnique = true)]
        [ListViewColumn]
        public string Description { get; set; }
    }
}