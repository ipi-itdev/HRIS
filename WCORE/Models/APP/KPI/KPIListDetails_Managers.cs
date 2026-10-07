using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "KPI")]
    [DatabaseTable(Name = "PIS_PerfIndicatorList")]
    public class KPIListDetails_Managers
    {
        [Display(Name = "Description")]
        [DatabaseField(IsRequired = true)]
        [ListViewColumn]
        [DetailViewItem(IsTextArea = true)]
        public string Description { get; set; }

        [Display(Name = "Weight")]
        [DatabaseField(IsRequired = true)]
        [ListViewColumn]
        [DetailViewItem(IsTextArea = true)]
        public int weight { get; set; }

        [Display(Name = "Status")]
        [DatabaseField(IsRequired = true)]
        [ListViewColumn]
        [DetailViewItem(IsTextArea = true)]
        public string Status { get; set; }

        [Display(Name = "Created By")]
        [DatabaseField(IsRequired = true)]
        [ListViewColumn]
        [DetailViewItem(IsTextArea = true)]
        public int CreatedBy { get; set; }
    }
}