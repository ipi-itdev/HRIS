using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "Commission")]
    [DatabaseTable(Name = "CS_CommissionDetailsDetails_Temp")]
    public class CommissionDetailsDetailsTemp : BaseObject
    {
        [DatabaseField]
        public int CommissionRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "Client")]
        [DetailViewItem(IsEnabled =false)]
        [DatabaseField(Name = "ClientAccountRefNo", RefModel = typeof(ClientAccount), RefField = "Description", RefAlias = "Client", RefTableAlias = "CL")]
        public int ClientAccountRefNo { get; set; }

        [Display(Name = "OR No")]
        [DatabaseField]
        [ListViewColumn]
        [DetailViewItem(IsEnabled = false)]
        public string ORNo { get; set; }

        [Display(Name = "Collection")]
        [DatabaseField]
        [DetailViewItem(IsEnabled = false)]
        public decimal NetAmount { get; set; }

        [Display(Name = "EWT%")]
        [DatabaseField]
        [DetailViewItem(IsEnabled = false)]
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

        [DetailViewItem(TabName = "Cost")]
        [DBCollection(ForeignKey = "CommissionDetailsDetailsRefNo", ForeignKeyValue = "ID", ModelNo = "3355")]
        public List<CommissionDetailsDetailsTempCost> CommissionDetailsDetailsTempCost { get; set; }
    }
}