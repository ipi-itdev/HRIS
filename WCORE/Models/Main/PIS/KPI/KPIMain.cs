using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "KPI List")]
    [DatabaseTable(Name = "PIS_PerfIndicatorList", ViewName = "dbo.fKPerfIndicatorFilter(@User)", PKeyName = "ID")]
    public class KPIMain : BaseObject
    {
        [Display(Name = "KPI Group Name")]
        [DetailViewItem]
        [DatabaseField(IsRequired = true, IsUnique = true)]
        [ListViewColumn]
        public string Description { get; set; }

        [DetailViewItem(TabName = "KPI Details")]
        [DBCollection(ForeignKey = "PerfIndicatorListRefNo", ForeignKeyValue = "ID", ModelNo = "1003")]
        public List<KPIDetails> KPIDetails { get; set; }

    }
}