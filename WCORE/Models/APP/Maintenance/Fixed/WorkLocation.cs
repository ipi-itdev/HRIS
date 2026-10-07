using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name="Work Location")]
    [DatabaseTable(Name = "PORTAL_WorkLocation_U", PKeyName = "ID")]
    public class WorkLocation : BaseObject
    {
        [DatabaseField(IsRequired=true,IsUnique =true)]
        [ListViewColumn]
        [DetailViewItem(IsTextArea=true)]
        public string Description { get; set; }
    }
}