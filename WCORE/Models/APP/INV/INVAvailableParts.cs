using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name="Items")]
    [DatabaseTable(Name = "dbo.fINVAvailableParts()", PKeyName = "ID")]
    public class INVAvailableParts : BaseObject
    {
        [Display(Name = "Item")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem]
        [ListViewColumn]
        public string Description { get; set; }
    }
}