using System;
using System.Linq;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "Chart of Account")]
    [DatabaseTable(Name = "CS_ChartofAccount_U", PKeyName = "ID")]
    public class ChartofAccount : BaseObject
    {
        [DatabaseField]
        [ListViewColumn]
        [DetailViewItem]
        public string Code { get; set; }

        [DatabaseField(IsRequired = true)]
        [ListViewColumn]
        [DetailViewItem(IsTextArea = true)]
        public string Description { get; set; }

        [DataLookUp]
        [Display(Name = "Account Type")]
        [DatabaseField(IsRequired = true, Name = "ID", RefModel = typeof(AccountType), RefField = "ID", RefAlias = "AT", RefTableAlias = "AT")]
        [ListViewColumn]
        [DetailViewItem]
        public int MRRefNo { get; set; }
    }
}