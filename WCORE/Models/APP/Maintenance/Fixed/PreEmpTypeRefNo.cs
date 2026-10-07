using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name= "Pre-Employment Requirement")]
    [DatabaseTable(Name = "GEN_PreEmploymentRequirement_F", PKeyName = "ID")]
    public class PreEmpTypeRefNo : BaseObject
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