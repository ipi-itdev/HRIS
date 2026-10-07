using System;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "Employee", SubName = "Active")]
    [DatabaseTable(Name = "dbo.PORTAL_ContactDetailsHistory_C", PKeyName = "ID")]
    public class AuditEmployeeHistoryDetails : BaseObject
    {
        [DatabaseField]
        public int ContactHistoryRefNo { get; set; }

        [Display(Name = "Field Name")]
        [DatabaseField]
        [DetailViewItem]
        public string FieldName { get; set; }

        [Display(Name = "Old Value")]
        [DatabaseField]
        [DetailViewItem]
        public string OldValue { get; set; }

        [Display(Name = "New Value")]
        [DatabaseField]
        [DetailViewItem]
        public string NewValue { get; set; }
    }
}