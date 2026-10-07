using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "KPI")]
    [DatabaseTable(Name = "PIS_KPI_U")]
    public class KPI : BaseObject
    {
        [DatabaseField()]
        public int EmployeeRefNo { get; set; }

        [Display(Name = "Description")]
        [DatabaseField(IsRequired = true)]
        [ListViewColumn]
        [DetailViewItem(IsTextArea = true)]
        public string KPIDescription { get; set; }

        [Display(Name = "Type")]
        [DatabaseField(IsRequired = true)]
        [ListViewColumn]
        [DetailViewItem]
        public int KPIType { get; set; }

        [Display(Name = "Target")]
        [DatabaseField(IsRequired = true)]
        [ListViewColumn]
        [DetailViewItem]
        public decimal KPITarget { get; set; }

        [Display(Name = "Output")]
        [DatabaseField]
        [ListViewColumn]
        [DetailViewItem]
        public decimal KPIOutput { get; set; }

        [Display(Name = "Accomplish")]
        [DatabaseField]
        [ListViewColumn]
        [DetailViewItem]
        public decimal KPIAccomplish { get; set; }

        [Display(Name = "Rating")]
        [DatabaseField]
        [ListViewColumn]
        [DetailViewItem(IsEnabled = false, Column = 2)]
        public decimal KPIRating { get; set; }

        [Display(Name = "Weight")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(IsEnabled = false, Column = 2)]
        public decimal KPIWeight { get; set; }

        [Display(Name = "Score")]
        [DatabaseField(IsRequired = true)]
        [ListViewColumn]
        [DetailViewItem(IsEnabled = false, Column = 2)]
        public decimal KPIScore { get; set; }

        [Display(Name = "Year")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(IsEnabled = false, Column = 2)]
        public decimal KPIYear { get; set; }

        [DatabaseField]
        [DetailViewItem(IsTextArea = true, Column = 2)]
        public string Remarks { get; set; }
    }
}