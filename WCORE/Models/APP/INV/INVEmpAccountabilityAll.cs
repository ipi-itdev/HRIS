using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "VIEW_INV_EmpAccountabilityAll")]
    [DatabaseTable(Name = "VIEW_INV_EmpAccountabilityAll", PKeyName = "ID")]
    public class VIEW_INV_EmpAccountabilityAll: BaseObject
    {
        [DatabaseField()]
        public int EmployeeRefNo { get; set; }

        [Display(Name = "EmployeeName")]
        [DatabaseField]
        public string EmployeeName { get; set; }

        [Display(Name = "DeployedDate")]
        [DatabaseField]
        public string DeployedDate { get; set; }

        [Display(Name = "ClearDate")]
        [DatabaseField]
        public string ClearDate { get; set; }

        [Display(Name = "ClearBy")]
        [DatabaseField]
        public string ClearBy { get; set; }
    }
}