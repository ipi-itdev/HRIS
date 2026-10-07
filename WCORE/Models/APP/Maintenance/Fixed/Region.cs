using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "Region")]
    [DatabaseTable(Name = "GEN_Region_M", PKeyName = "RegionRefNo")]
    //[DatabaseTable(Name = "View_Region", PKeyName = "RegionRefNo")]
    public class Region : BaseObject
    {
        [DetailViewItem(IsTextArea = true)]
        [DatabaseField(IsRequired = true, IsUnique = true)]
        [ListViewColumn]
        public string Description { get; set; }
    }
}