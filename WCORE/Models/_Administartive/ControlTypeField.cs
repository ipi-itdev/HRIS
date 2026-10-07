using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "Control Type")]
    [DatabaseTable(Name = "SYS_ControlType_U", PKeyName = "ControlTypeRefNo")]
    public class ControlTypeField : BaseObject
    {
        [DatabaseField(IsRequired = true)]
        [ListViewColumn]
        [DetailViewItem(IsTextArea = true)]
        public string Description { get; set; }
    }
}