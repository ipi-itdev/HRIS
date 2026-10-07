using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "Job Position")]
    [DatabaseTable(Name = "GEN_JobPosition_M", PKeyName = "JobPositionRefNo")]
    public class JobPosition : BaseObject
    {

        [DetailViewItem]
        [DatabaseField(IsRequired = true, IsUnique = true)]
        [ListViewColumn]
        public string Code { get; set; }

        [DetailViewItem(IsTextArea = true)]
        [DatabaseField(IsRequired = true, IsUnique = true)]
        [ListViewColumn]
        public string Description { get; set; }

        [DetailViewItem]
        [Display(Name = "IT")]
        [DatabaseField]
        [ListViewColumn]
        public Boolean IsIT { get; set; }
    }
}