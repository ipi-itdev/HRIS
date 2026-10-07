using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "Employee", SubName = "Active")]
    [DatabaseTable(Name = "PIS_Employee_U", ViewName = "dbo.fINVEmployeeMasterlist(2)", PKeyName = "EmployeeRefNo")]
    public class INVEXTEmployeeMasterlist : BaseObject
    {
        [DatabaseField()]
        public int EmployeeRefNo { get; set; }

        [Display(Name = "Employee Number")]
        [DatabaseField]
        [ListViewColumn]
        [DetailViewItem(IsEnabled = false, Column = 2)]
        public string EmployeeNumber { get; set; }
        
        [Display(Name = "Employee Name")]
        [DatabaseField(AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn]
        public string Description { get; set; }
    }
}