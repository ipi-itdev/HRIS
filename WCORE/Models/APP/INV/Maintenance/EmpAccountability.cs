using WCORE.Utility;

namespace WCORE.Models
{
    [DatabaseTable(Name = "vEmpAccountability",PKeyName = "EmployeeRefNo")]
    public class EmpAccountability : BaseObject
    {
        [DatabaseField]
        public int EmployeeRefNo { get; set; }

        [DatabaseField]
        [ListViewColumn]
        public string Description { get; set; }
    }
}


