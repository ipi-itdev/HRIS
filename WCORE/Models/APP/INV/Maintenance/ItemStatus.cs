using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name="Item Status")]
    [DatabaseTable(Name = "INV_ItemStatus_F", PKeyName = "ID")]
    public class ItemStatus : BaseObject
    {
      [DatabaseField]
      [DetailViewItem(IsTextArea = true)]
      [ListViewColumn]
      public string Description { get; set; }
    }
}