using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "Marketing Representative")]
    [DatabaseTable(Name = "GEN_MR_M", PKeyName = "MRRefNo")]
    public class MarketingRep : BaseObject
    {

        [Display(Name = "Code")]
        [DetailViewItem]
        [DatabaseField(IsRequired = true, IsUnique = true)]
        [ListViewColumn]
        public string Description { get; set; }

        [Display(Name = "Local No")]
        [ListViewColumn]
        [DetailViewItem]
        [DatabaseField]
        public string localNo { get; set; }
    }
}