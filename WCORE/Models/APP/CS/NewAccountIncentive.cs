using System;
using System.Linq;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "New Name Account Incentives")]
    [DatabaseTable(Name = "CS_NewAccountIncentives_U", PKeyName = "ID")]
    public class NewAccountIncentive : BaseObject
    {
        [Display(Name ="GM From")]
        [DatabaseField(IsRequired =true)]
        [ListViewColumn]
        [DetailViewItem]
        public decimal FromAmount  { get; set; }

        [Display(Name = "GM To")]
        [DatabaseField(IsRequired =true)]
        [ListViewColumn]
        [DetailViewItem]
        public decimal ToAmount { get; set; }

        [Display(Name = "Incentive")]
        [DatabaseField(IsRequired =true)]
        [ListViewColumn]
        [DetailViewItem]
        public decimal IncentiveAmount { get; set; }
    }
}