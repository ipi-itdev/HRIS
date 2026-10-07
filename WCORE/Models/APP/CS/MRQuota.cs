using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;
using WCORE.Models;

namespace WCORE.Models
{
    [MenuDescription(Name = "MR Quota")]
    [DatabaseTable(Name = "CS_MRQuota_U")]
    public partial class MRQuota : BaseObject
    {
        [DataLookUp]
        [Display(Name = "MR")]
        [DatabaseField(AllowUpdate =false, IsRequired = true, Name = "MRRefNo", RefModel = typeof(MarketingRep), RefField = "Description", RefAlias = "CA", RefTableAlias = "CAA")]
        [ListViewColumn]
        [DetailViewItem]
        public int MRRefNo { get; set; }

        [DatabaseField(IsRequired = true,AllowUpdate =false)]
        [ListViewColumn]
        [DetailViewItem]
        public int Year { get; set; }

        [Display(Name ="GM Quota")]
        [DatabaseField]
        [DetailViewItem(IsEnabled =false)]
        [ListViewColumn]
        public decimal Amount { get; set; }

        [Display(Name = "YTD Performance")]
        [DatabaseField]
        [DetailViewItem(IsEnabled = false)]
        [ListViewColumn]
        public decimal YTDPerformance { get; set; }

        [Display(Name = "YTD Achievement")]
        [DatabaseField]
        [DetailViewItem(IsEnabled = false)]
        [ListViewColumn]
        public decimal YTDAchievement { get; set; }

        [Display(Name = "AQ Achievement")]
        [DatabaseField]
        [DetailViewItem(IsEnabled =false)]
        [ListViewColumn]
        public decimal AQAchievement { get; set; }

        [DetailViewItem(TabName = "Details")]
        [DBCollection(ForeignKey = "MRQuotaRefNo", ForeignKeyValue = "ID", ModelNo = "3410")]
        public List<MRQuotaDetails> MRQuotaDetails { get; set; }
    }
}