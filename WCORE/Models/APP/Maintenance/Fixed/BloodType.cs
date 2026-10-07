using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name="Blood Type")]
    [DatabaseTable(Name = "GEN_BloodType_M", PKeyName = "BloodtypeRefNo")]
    public class BloodType : BaseObject
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