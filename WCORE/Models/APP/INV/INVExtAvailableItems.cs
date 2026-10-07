using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name="Items")]
    [DatabaseTable(Name = "dbo.fINVItemsAvailable(1)", PKeyName = "ID")]
    public class INVExtAvailableItems : BaseObject
    {
        [Display(Name = "Item")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem]
        [ListViewColumn]
        public string Description { get; set; }
    }
}