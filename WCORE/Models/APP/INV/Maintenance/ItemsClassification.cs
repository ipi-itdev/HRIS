using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name="Classification")]
    [DatabaseTable(Name = "INV_ItemsClassification_F", PKeyName = "ID")]
    public class ItemsClassification : BaseObject
    {
      [DatabaseField(IsRequired = true, IsUnique = true)]
      [DetailViewItem(IsTextArea = true, TabName = "Details")]
      [ListViewColumn]
      public string Description { get; set; }

      [Display(Name = "Is Parts?")]
      [DatabaseField]
      [DetailViewItem(TabName ="Details")]
      [ListViewColumn]
      public bool IsParts { get; set; }

      
    }
}