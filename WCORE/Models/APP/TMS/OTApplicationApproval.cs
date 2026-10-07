using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "OT Application", SubName = "Approval")]
    [DatabaseTable(Name = "PORTAL_OvertimeApplication_U", ViewName = "dbo.fnOTApplication(@User)")]
    public class OTApplicationApproval : BaseObject
    {
        [Display(Name = "MR/Manager")]
        [DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn(Width = 20)]
        public string MR { get; set; }

        [Display(Name = "Employee Number")]
        [DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn]
        public string EmployeeNumber { get; set; }

        [Display(Name = "Employee Name")]
        [DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn]
        public string EmployeeName { get; set; }

        [Display(Name = "Department/Client")]
        [DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn]
        public string DEPClient { get; set; }

        [Display(Name = "Date Filed")]
        [DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn]
        public string DateFiled { get; set; }

        [Display(Name = "Work Date")]
        [DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn]
        public string WorkDate { get; set; }

        [Display(Name = "Status")]
        [DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn]
        public string FilingStatus { get; set; }

    }
}