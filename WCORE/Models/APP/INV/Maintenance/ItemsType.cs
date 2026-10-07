using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name="Item Type")]
    [DatabaseTable(Name = "INV_ItemsType_F", PKeyName = "ID")]
    public class ItemsType : BaseObject
    {
        [DataLookUp]
        [Display(Name = "Item Classification")]
        [DatabaseField(IsRequired = true, RefModel = typeof(ItemsClassification), RefField = "Description", RefTableAlias = "IC", Name = "ID", RefAlias = "IC")]
        [DetailViewItem]
        [ListViewColumn]
        public int ClassificationRefNo { get; set; }

        [Display(Name = "Item Type")]
        [DatabaseField(IsRequired =true)]
        [DetailViewItem]
        [ListViewColumn]
        public string ItemType { get; set; }

        [DetailViewItem(IsEnabled =false)]
        [DatabaseField]
        [ListViewColumn]
        public string Description { get; set; }

        [DatabaseField]
        [DetailViewItem(IsTextEditor = true,TabName ="Specifications")]
        public string Specifications { get; set; }
    }
}


