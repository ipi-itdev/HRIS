using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "Commission")]
    [DatabaseTable(Name = "CS_CommissionDetailsDetails_U")]
    public class CommissionDetailsDetails : BaseObject
    {
        [DatabaseField]
        public int CommissionRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "Client")]
        [DetailViewItem]
        [DatabaseField(IsRequired = true, Name = "ClientAccountRefNo", RefModel = typeof(ClientAccount), RefField = "Description", RefAlias = "Client", RefTableAlias = "CL")]
        public int ClientAccountRefNo { get; set; }

        [Display(Name = "OR No")]
        [DatabaseField]
        [ListViewColumn]
        [DetailViewItem]
        public string ORNo { get; set; }

        [Display(Name = "Collection")]
        [DatabaseField]
        [DetailViewItem]
        public decimal NetAmount { get; set; }

        [Display(Name = "EWT%")]
        [DatabaseField]
        [DetailViewItem]
        public decimal EWT { get; set; }
        
        [Display(Name = "GR EWT")]
        [DatabaseField]
        [DetailViewItem(IsEnabled = false)]
        public decimal GREWT { get; set; }

        [Display(Name = "DC")]
        [DatabaseField]
        [DetailViewItem(IsEnabled = false)]
        public decimal DC { get; set; }

        [Display(Name = "Gross Margin")]
        [DatabaseField]
        [DetailViewItem(IsEnabled = false)]
        public decimal GM { get; set; }

        [Display(Name = "GM %")]
        [DatabaseField]
        [DetailViewItem(IsEnabled = false)]
        public decimal GMP { get; set; }

        [Display(Name = "CR %")]
        [DatabaseField]
        [DetailViewItem(IsEnabled = false)]
        public decimal CR { get; set; }

        [DatabaseField]
        [DetailViewItem(IsEnabled = false)]
        public decimal Commission { get; set; }
    }
}