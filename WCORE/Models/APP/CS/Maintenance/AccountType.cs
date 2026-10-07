using System;
using System.Linq;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "Account Type")]
    [DatabaseTable(Name = "CS_AccountType_U", PKeyName = "ID")]
    public class AccountType : BaseObject
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