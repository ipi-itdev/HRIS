using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name="Item Details")]
    [DatabaseTable(Name = "INV_ItemsDetails_U", ViewName = "vINVItemDetails")]
    public class INVItemDetails : BaseObject
    {
        [DatabaseField]
        public int ItemsRefNo { get; set; }

        [Display(Name = "Item")]
        [DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn]
        public string ItemType { get; set; }

        [Display(Name = "Specification")]
        [DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn]
        public string Description { get; set; }

        [DataLookUp]
        [Display(Name = "Item")]
        [DatabaseField(IsRequired = true, RefModel = typeof(INVAvailableParts), RefField = "ItemName", RefTableAlias = "DT", Name = "ID", RefAlias = "DT",AllowUpdate =false)]
        [DetailViewItem]
        public int ItemDetailsRefNo { get; set; }

        [DatabaseField(AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn]
        public string Remarks { get; set; }
    }
}





