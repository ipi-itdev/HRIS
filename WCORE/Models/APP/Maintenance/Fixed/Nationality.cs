using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name="Nationality")]
    [DatabaseTable(Name = "GEN_Nationality_M", PKeyName = "NationalityRefNo")]
    public class Nationality : BaseObject
    {
        [DatabaseField(IsRequired=true,IsUnique =true)]
        [ListViewColumn]
        [DetailViewItem(IsTextArea=true)]
        public string Description { get; set; }
    }
}