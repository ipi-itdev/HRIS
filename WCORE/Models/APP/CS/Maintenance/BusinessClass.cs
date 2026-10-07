using System;
using System.Linq;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "Business Type")]
    [DatabaseTable(Name = "CS_BusinessClass_U", PKeyName = "ID")]
    public class BusinessType : BaseObject
    {
        [DatabaseField]
        [ListViewColumn]
        [DetailViewItem]
        public string Code { get; set; }

        [DatabaseField(IsRequired = true)]
        [ListViewColumn]
        [DetailViewItem(IsTextArea = true)]
        public string Description { get; set; }
    }
}