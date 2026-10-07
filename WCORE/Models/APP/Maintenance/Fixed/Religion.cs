using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name="Religion")]
    [DatabaseTable(Name = "GEN_Religion_M", PKeyName = "ReligionRefNo")]
    public class Religion : BaseObject
    {
        [DatabaseField(IsRequired=true,IsUnique =true)]
        [ListViewColumn]
        [DetailViewItem(IsTextArea=true)]
        public string Description { get; set; }
    }
}