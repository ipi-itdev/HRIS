using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name="FormType")]
    [DatabaseTable(Name = "SYS_FormType_F", PKeyName = "FormTypeRefNo")]
    public class FormType : BaseObject
    {
        [DatabaseField(IsRequired = true)]
        [ListViewColumn]
        [DetailViewItem(IsTextArea = true)]
        public string Description { get; set; }
    }
}