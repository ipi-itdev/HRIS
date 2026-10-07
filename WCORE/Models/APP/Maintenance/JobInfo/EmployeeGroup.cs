using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "Employee Group")]
    [DatabaseTable(Name = "GEN_EmployeeGroup_F", PKeyName = "EmployeeGroupRefNo")]
    public class EmployeeGroup : BaseObject
    {
        [DatabaseField]
        [ListViewColumn]
        [DetailViewItem]
        public string Code { get; set; }

        [DatabaseField(IsRequired=true)]
        [ListViewColumn]
        [DetailViewItem(IsTextArea=true)]
        public string Description { get; set; }
    }
}