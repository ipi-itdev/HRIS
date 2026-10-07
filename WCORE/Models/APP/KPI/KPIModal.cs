using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "KPI Details")]
    [DatabaseTable(Name = "PIS_KPIDetailsPerEmployee", ViewName = "dbo.fGetKPIListDetails()", PKeyName = "ID")]
    public class KPIModal : BaseObject
    {

        [Display(Name = "KPIIndicator")]
        [DatabaseField(AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn]
        public string KPIIndicator { get; set; }


        [Display(Name = "KPIType")]
        [DatabaseField(AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn]
        public string KPIType { get; set; }

        [Display(Name = "KPIWeight")]
        [DatabaseField(AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn]
        public string KPIWeight { get; set; }

        [Display(Name = "KPITarget")]
        [DatabaseField(AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn]
        public string KPITarget { get; set; }



    }
}