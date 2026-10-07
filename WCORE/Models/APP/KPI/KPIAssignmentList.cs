using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "KPI Details")]
    [DatabaseTable(Name = "PIS_KPIAssigmentList", ViewName = "dbo.fKPIAssigmentListFilter()", PKeyName = "ID")]
    public class KPIAssignmentList : BaseObject
    {
        [DataLookUp]
        [DetailViewItem]
        [ListViewColumn]
        [Display(Name = "Job Title")]
        [DatabaseField(Name = "JobPositionRefNo", RefModel = typeof(KPIJobTitleSelect), RefField = "Description", RefAlias = "E", RefTableAlias = "E",
            IsRequired = true)]
        public int JobPositionRefNo { get; set; }

        [DataLookUp]
        [DetailViewItem]
        [ListViewColumn]
        [Display(Name = "KPI Group Name")]
        [DatabaseField(Name = "ID", RefModel = typeof(PerformanceIndicatorSelect), RefField = "Description", RefAlias = "EGroup", RefTableAlias = "EGroup",
            IsRequired = true)]
        public int PerfIndicatorListRefNo { get; set; }

        [DetailViewItem(TabName = "Assigned To")]
        [DBCollection(ForeignKey = "KPIAssignmentRefNo", ForeignKeyValue = "ID")]
        public List<KPIAssignedTo> KPIAssignedTo { get; set; }

    }
}