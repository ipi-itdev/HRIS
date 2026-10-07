using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "FS Quota Details")]
    [DatabaseTable(Name = "CS_FSQuotaDetails_U")]
    public partial class FSQuotaDetails : BaseObject
    {
        [DatabaseField]
        public int FSQuotaRefNo { get; set; }

        [DataLookUp(IsJson = true)]
        [Display(Name = "Month")]
        [DatabaseField(IsRequired = true,Name = "ID", RefModel = typeof(Month), RefField = "MonthRefNo", RefAlias = "M", RefTableAlias = "M")]
        [ListViewColumn]
        [DetailViewItem]
        public int MonthRefNo { get; set; }
        
        [DatabaseField(IsRequired=true)]
        [DetailViewItem]
        [ListViewColumn]
        public decimal GNP { get; set; }

        [Display(Name = "MR Commission")]
        [DatabaseField]
        [DetailViewItem(IsEnabled =false)]
        [ListViewColumn]
        public decimal MRCommission { get; set; }

        [Display(Name = "GNP + MR Commission")]
        [DatabaseField]
        [DetailViewItem(IsEnabled = false)]
        [ListViewColumn]
        public decimal GNPMRCommission { get; set; }

        [Display(Name = "YTD Performance")]
        [DatabaseField]
        [DetailViewItem(IsEnabled = false)]
        [ListViewColumn]
        public decimal YTDPerformance { get; set; }

        [Display(Name = "AQ Achievement")]
        [DatabaseField]
        [DetailViewItem(IsEnabled = false)]
        [ListViewColumn]
        public decimal AQAchievement { get; set; }

        [Display(Name = "Commission Rate")]
        [DatabaseField]
        [DetailViewItem(IsEnabled = false)]
        [ListViewColumn]
        public decimal CommissionRate { get; set; }

        [Display(Name = "FS Commission")]
        [DatabaseField]
        [DetailViewItem(IsEnabled = false)]
        [ListViewColumn]
        public decimal FSCommission { get; set; }
    }
}