using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "Employee", SubName = "Active")]
    [DatabaseTable(Name = "dbo.PORTAL_ContactHistory_C", PKeyName = "ID")]
    public class AuditEmployeeHistory : BaseObject
    {
        [DataLookUp]
        [Display(Name = "Employee")]
        [DatabaseField(AllowUpdate = false, RefModel = typeof(Employee), RefField = "Description", RefTableAlias = "emp", Name = "EmployeeRefNo", RefAlias = "emp")]
        [DetailViewItem(IsEnabled = false)]
        [ListViewColumn]
        public int EmployeeRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "Approved By")]
        [DatabaseField(AllowUpdate = false, RefModel = typeof(User), RefField = "Description", RefTableAlias = "user", Name = "ID", RefAlias = "user")]
        [DetailViewItem(IsEnabled = false)]
        [ListViewColumn]
        public int ConfirmedBy { get; set; }

        [Display(Name = "Approved Date")]
        [DatabaseField]
        [DetailViewItem(IsEnabled = false)]
        public DateTime ConfirmedDate { get; set; }

        [Display(Name = "Audit")]
        [DetailViewItem(TabName = "Audit", IsDiffSave = true)]
        [DBCollection(ForeignKey = "ContactHistoryRefNo", ForeignKeyValue = "ID", ModelNo = "91")]
        public List<AuditEmployeeHistoryDetails> AuditEmployeeHistoryDetails { get; set; }
    }
}