using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "KPI")]
    //[DatabaseTable(Name = "GEN_ClientAccount_M")]
    //fGetKPIListsClient_2  fGetKPIListsClient(@UserRefNo)
    //[DatabaseTable(Name = "fGetKPIListsClient_2")]
    [DatabaseTable(Name = "PIS_KPIAssigmentList", ViewName = "dbo.fKPIAssigmentListFilter()", PKeyName = "ID")]
    public class AssignedToExternal : BaseObject
    {

        //[Display(Name = "Client")]
        //[DataLookUp]
        //[DatabaseField(Name = "ID2", RefModel = typeof(AssignedToExternalList), RefField = "Decription", RefAlias = "E", RefTableAlias = "E",
        //    IsRequired = true)]
        //[ListViewColumn]
        //[DetailViewItem(IsTextArea = true)]
        //public int ID2 { get; set; } // this can be also used for display name when DisplayName attribute is commented

        //[Display(Name = "KPI Group Name")]
        //[DataLookUp]
        //[DatabaseField(IsRequired = true, Name = "ID3", RefModel = typeof(AssignedToExternalList2), RefField = "Description")]
        //[ListViewColumn]
        //[DetailViewItem(IsTextArea = true)]
        //public int ID3 { get; set; }

        [DataLookUp]
        [DetailViewItem]
        [ListViewColumn]
        [Display(Name = "Client")]
        [DatabaseField(Name = "JobPositionRefNo", RefModel = typeof(KPIClientSelect), RefField = "Description", RefAlias = "E", RefTableAlias = "E",
            IsRequired = true)]
        public int JobPositionRefNo { get; set; }

        [DataLookUp]
        [DetailViewItem]
        [ListViewColumn]
        [Display(Name = "KPI Group Name")]
        [DatabaseField(Name = "ID", RefModel = typeof(PerformanceIndicatorSelect), RefField = "Description", RefAlias = "EGroup", RefTableAlias = "EGroup"
            )]
        public int PerfIndicatorListRefNo { get; set; }

        //[DetailViewItem(TabName = "Assigned To")]
        //[DBCollection(ForeignKey = "KPIAssignmentRefNo", ForeignKeyValue = "ID")]
        //public List<KPIAssignedTo> KPIAssignedTo { get; set; }

    }
}