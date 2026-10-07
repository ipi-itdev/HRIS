using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "Commission")]
    [DatabaseTable(Name = "CS_CommissionIncentives_U")]
    public class CommissionIncentives : BaseObject
    {
        [DatabaseField]
        public int CommissionRefNo { get; set; }

        [DatabaseField(IsRequired = true)]
        [ListViewColumn]
        [DetailViewItem]
        public string Description { get; set; }

        [ListViewColumn]
        [DatabaseField(IsRequired =true)]
        [DetailViewItem]
        public decimal Amount { get; set; }
    }
}