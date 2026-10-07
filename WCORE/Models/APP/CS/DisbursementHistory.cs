using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;
using WCORE.Models;
using System;

namespace WCORE.Models
{
    [MenuDescription(Name = "Disbursement")]
    [DatabaseTable(Name = "BIL_Disbursement_U")]
    public partial class DisbursementHistory : BaseObject
    {
        [DatabaseField]
        [ListViewColumn]
        [DetailViewItem(IsEnabled =false)]
        public string CVNo { get; set; }

        [DatabaseField]
        [ListViewColumn]
        [DetailViewItem(IsEnabled = false)]
        public decimal Amount { get; set; }

        [Display(Name = "Start Date")]
        [DatabaseField]
        [ListViewColumn]
        [DetailViewItem(IsEnabled = false)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DatabaseField]
        [ListViewColumn]
        [DetailViewItem(IsEnabled = false)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Monthly Amortization")]
        [DatabaseField]
        [DetailViewItem(IsEnabled =false)]
        [ListViewColumn]
        public decimal MonthlyAmortization { get; set; }

        [DatabaseField]
        [DetailViewItem]
        [ListViewColumn]
        public decimal Balance { get; set; }

        [Display(Name = "Is Cleared?")]
        [DatabaseField]
        [DetailViewItem]
        [ListViewColumn]
        public bool IsCleared { get; set; }

        [Display(Name = "Is Complete?")]
        [DatabaseField]
        [DetailViewItem]
        [ListViewColumn]
        public bool IsComplete { get; set; }
    }
}