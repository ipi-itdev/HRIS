using System;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "Separation Pay")]
    [DatabaseTable(Name = "CS_SeparationPay_U")]
    public partial class SeparationPay : BaseObject
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
        
        [Display(Name = "Separation Pay")]
        [DatabaseField(IsRequired=true)]
        [DetailViewItem]
        [ListViewColumn]
        public decimal Amount { get; set; }

        [Display(Name= "GM %")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem]
        [ListViewColumn]
        public decimal GMP { get; set; }

        [Display(Name = "CR %")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem]
        [ListViewColumn]
        public decimal CR { get; set; }

        [Display(Name = "SP Cost")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem]
        [ListViewColumn]
        public decimal SPCost { get; set; }
    }
}