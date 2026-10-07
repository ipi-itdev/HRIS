using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name="Holiday Type")]
    [DatabaseTable(Name = "GEN_HolidayType_M", PKeyName = "HolidayTypeRefNo")]
    public class HolidayType : BaseObject
    {
        [DatabaseField]
        [ListViewColumn]
        [DetailViewItem]
        public string Code { get; set; }

        [DatabaseField(IsRequired=true, IsUnique = true)]
        [ListViewColumn]
        [DetailViewItem(IsTextArea=true)]
        public string Description { get; set; }
    }
}