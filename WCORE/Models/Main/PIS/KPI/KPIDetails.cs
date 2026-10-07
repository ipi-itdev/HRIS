using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "KPI Details")]
    [DatabaseTable(Name = "PIS_PerfIndicatorListDetails", PKeyName = "ID")]
    public class KPIDetails : BaseObject
    {
        [Display(Name = "Description")]
        [DetailViewItem(IsTextArea = true)]
        [DatabaseField(IsRequired = true, IsUnique = true)]
        [ListViewColumn]
        public string Description { get; set; }

        [DataLookUp]
        [DetailViewItem]
        [ListViewColumn]
        [Display(Name = "Formula")]
        [DatabaseField(Name = "KPIDetailsTypeRefNo", RefModel = typeof(KPIDetailsType), RefField = "Description", RefAlias = "E", RefTableAlias = "E", IsRequired = true)]
        public int KPIDetailsTypeRefNo { get; set; }

        [Display(Name = "Weight")]
        [DetailViewItem]
        [DatabaseField(IsRequired = true, IsUnique = false)]
        [ListViewColumn]
        public decimal Weight { get; set; }

        [DatabaseField(IsRequired = true)]
        public decimal PerfIndicatorListRefNo { get; set; }
    }
}