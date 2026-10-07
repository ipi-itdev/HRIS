using System;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "Late Payments")]
    [DatabaseTable(Name = "BIL_LatePayment_C")]
    public partial class LatePayments : BaseObject
    {
        [DataLookUp]
        [Display(Name = "Client")]
        [DetailViewItem]
        [DatabaseField(IsRequired = true, Name = "ClientAccountRefNo", RefModel = typeof(ClientAccount), RefField = "Description", RefAlias = "Client", RefTableAlias = "CL")]
        public int ClientAccountRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "Month")]
        [DetailViewItem]
        [DatabaseField(IsRequired = true, Name = "MonthRefNo", RefModel = typeof(Month), RefField = "Description", RefAlias = "Month", RefTableAlias = "M")]
        public int MonthRefNo { get; set; }

        [DatabaseField(IsRequired = true)]
        [ListViewColumn]
        [DetailViewItem]
        public int Year { get; set; }

        [DatabaseField(IsRequired = true)]
        [DetailViewItem]
        [ListViewColumn]
        public DateTime DateReceived { get; set; }

        [DatabaseField(IsRequired = true)]
        [ListViewColumn]
        [DetailViewItem]
        public int OverDueDays { get; set; }

        [DatabaseField(IsRequired=true)]
        [DetailViewItem]
        [ListViewColumn]
        public decimal Amount { get; set; }

        [Display(Name= "Penalty Amount")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem]
        [ListViewColumn]
        public decimal PenaltyAmount { get; set; }
    }
}