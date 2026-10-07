using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "DTR Application", SubName = "Approval")]
    [DatabaseTable(Name = "TMS_DTRApplicationHdr_U", ViewName = "dbo.fnDTRApplicationHistory(@User)")]
    public class DTRApplicationHistory : BaseObject
    {
        [Display(Name = "MR/Manager")]
        [DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn(Width = 20)]
        public string MR { get; set; }

        [Display(Name = "Employee Number")]
        [DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn(Width = 150)]
        public string EmployeeNumber { get; set; }

        [Display(Name = "Employee Name")]
        [DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn]
        public string EmployeeName { get; set; }

        [Display(Name = "Department/Client")]
        [DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn]
        public string DEPClient { get; set; }

        [Display(Name = "Work Period")]
        [DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn]
        public string WorkPeriod { get; set; }

        [Display(Name = "Payroll Date")]
        [DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn(Width = 100)]
        public string PayrollDate { get; set; }

   }
}