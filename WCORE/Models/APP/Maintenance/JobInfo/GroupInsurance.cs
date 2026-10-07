using System;
using System.Linq;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "Group Insurance")]
    [DatabaseTable(Name = "PIS_GroupInsurance_U", PKeyName = "ID")]
    public class GroupInsurance : BaseObject
    {
        [DetailViewItem]
        [DatabaseField(IsRequired = true, IsUnique = true)]
        [ListViewColumn]
        public string Description { get; set; }
    }
}