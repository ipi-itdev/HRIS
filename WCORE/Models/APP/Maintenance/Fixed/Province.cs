using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "Province")]
    [DatabaseTable(Name = "GEN_Province_M", PKeyName = "ProvinceRefNo")]
    //[DatabaseTable(Name = "View_Province", PKeyName = "ProvinceRefNo")]
    public class Province : BaseObject
    {
        [DataLookUp]
        [Display(Name = "Region")]
        [DatabaseField(IsRequired = true, RefModel = typeof(Region), RefField = "Description", RefTableAlias = "Reg", Name = "RegionRefNo", RefAlias = "Reg")]
        [DetailViewItem]
        [ListViewColumn]
        public int RegionRefNo { get; set; }

        [DetailViewItem(IsTextArea = true)]
        [DatabaseField(IsRequired = true, IsUnique = true)]
        [ListViewColumn]
        public string Description { get; set; }
    }
}