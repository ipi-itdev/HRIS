using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "Commission")]
    [DatabaseTable(Name = "CS_CommissionCost_U")]
    public class CommissionCost : BaseObject
    {
        [DatabaseField]
        public int CommissionRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "MR")]
        [DatabaseField(Name = "ID", RefModel = typeof(Disbursement), RefField = "Description", RefAlias = "DB", RefTableAlias = "DB")]
        [ListViewColumn]
        [DetailViewItem(IsEnabled = false)]
        public int DisbursementRefNo { get; set; }

        [DatabaseField(IsRequired =true)]
        [ListViewColumn]
        [DetailViewItem]
        public string Description { get; set; }

        [ListViewColumn]
        [DatabaseField(IsRequired =true)]
        [DetailViewItem]
        public decimal Amount { get; set; }
    }
}