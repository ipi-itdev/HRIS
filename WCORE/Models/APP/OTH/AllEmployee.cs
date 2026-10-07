using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "Employee", SubName = "Active")]
    [DatabaseTable(Name = "PIS_Employee_U", ViewName = "dbo.fSelectEmployeeAll()", PKeyName = "EmployeeRefNo")]
    public class AllEmployee : BaseObject
    {
        [DatabaseField]
        [ListViewColumn]
        [DetailViewItem]
        public int EmployeeRefNo { get; set; }

        [Display(Name = "Employee Name")]
        [DatabaseField(AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn]
        public string Description { get; set; }
    }
}