using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;
using WCORE.Models;
using System;

namespace WCORE.Models
{
    [MenuDescription(Name = "Disbursement")]
    [DatabaseTable(Name = "BIL_Disbursement_U")]
    public class Disbursement : BaseObject
    {
        [DatabaseField]
        public string Description { get; set; }

        [DatabaseField]
        [ListViewColumn]
        [DetailViewItem(IsEnabled =false)]
        public string CVNo { get; set; }

        [DatabaseField]
        [ListViewColumn]
        [DetailViewItem(IsEnabled = false)]
        public decimal Amount { get; set; }

        [Display(Name = "Net Amount")]
        [DatabaseField(IsRequired =true)]
        [ListViewColumn]
        [DetailViewItem]
        public decimal NetAmount { get; set; }

        [Display(Name = "Start Date")]
        [DatabaseField(IsRequired = true)]
        [ListViewColumn]
        [DetailViewItem]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DatabaseField(IsRequired = true)]
        [ListViewColumn]
        [DetailViewItem]
        public DateTime EndDate { get; set; }

        [Display(Name = "Monthly Amortization")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem]
        [ListViewColumn]
        public decimal MonthlyAmortization { get; set; }

        [DatabaseField]
        [DetailViewItem(IsEnabled = false)]
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