using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "MR Quota Details")]
    [DatabaseTable(Name = "CS_MRQuotaDetails_U")]
    public partial class MRQuotaDetails : BaseObject
    {
        [DatabaseField]
        public int MRQuotaRefNo { get; set; }

        [DataLookUp(IsJson = true)]
        [Display(Name = "Month")]
        [DatabaseField(IsRequired = true,Name = "ID", RefModel = typeof(Month), RefField = "MonthRefNo", RefAlias = "M", RefTableAlias = "M")]
        [ListViewColumn]
        [DetailViewItem]
        public int MonthRefNo { get; set; }
        
        [Display(Name = "Monthly Quota")]
        [DatabaseField(IsRequired=true)]
        [DetailViewItem]
        [ListViewColumn]
        public decimal MonthlyQuota { get; set; }

        [Display(Name = "YTD Quota")]
        [DatabaseField]
        [DetailViewItem(IsEnabled =false)]
        [ListViewColumn]
        public decimal YTDQuota { get; set; }


        [Display(Name = "Monthly Performance")]
        [DatabaseField]
        [DetailViewItem(IsEnabled = false)]
        [ListViewColumn]
        public decimal MonthlyPerformance { get; set; }

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
        [DetailViewItem(IsEnabled = false)]
        [ListViewColumn]
        public decimal AQAchievement { get; set; }
    }
}