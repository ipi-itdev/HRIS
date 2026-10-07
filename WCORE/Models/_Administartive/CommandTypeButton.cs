using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "Command Type")]
    [DatabaseTable(Name = "SYS_CommandType_F", PKeyName = "CommandTypeRefNo")]
    public class CommandTypeButton : BaseObject
    {
        [DatabaseField(IsRequired = true)]
        [ListViewColumn]
        [DetailViewItem(IsTextArea = true)]
        public string Description { get; set; }
    }
}