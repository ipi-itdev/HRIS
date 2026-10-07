using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "Commission")]
    [DatabaseTable(Name = "CS_Commission_U")]
    public partial class Commission : BaseObject
    {
        [DataLookUp]
        [Display(Name = "MR")]
        [DatabaseField(Name = "ID", RefModel = typeof(MarketingRep), RefField = "MRRefNo", RefAlias = "MR", RefTableAlias = "MR")]
        [ListViewColumn]
        [DetailViewItem(IsEnabled =false)]
        public int MRRefNo { get; set; }

        [DataLookUp(IsJson = true)]
        [Display(Name = "Month")]
        [DatabaseField(Name = "ID", RefModel = typeof(Month), RefField = "MonthRefNo", RefAlias = "M", RefTableAlias = "M")]
        [ListViewColumn]
        [DetailViewItem(IsEnabled = false)]
        public int MonthRefNo { get; set; }

        [Display(Name = "YTD Quota")]
        [DatabaseField]
        [DetailViewItem(IsEnabled = false)]
        public decimal YTDQuota { get; set; }

        [Display(Name = "YTD Performance")]
        [DatabaseField]
        [DetailViewItem(IsEnabled = false)]
        public decimal YTDPerformance { get; set; }

        [Display(Name = "YTD Performance %")]
        [DatabaseField]
        [DetailViewItem(IsEnabled = false)]
        public decimal YTDPerformancePercentage { get; set; }

        [Display(Name = "Gross Revenue")]
        [DatabaseField]
        [DetailViewItem(IsEnabled = false)]
        public decimal GR { get; set; }

        [Display(Name = "Direct Cost")]
        [DatabaseField]
        [DetailViewItem(IsEnabled = false)]
        public decimal DC { get; set; }

        [Display(Name = "Gross Margin")]
        [DatabaseField]
        [DetailViewItem(IsEnabled = false)]
        public decimal GM { get; set; }
        
        [Display(Name ="GM%")]
        [DatabaseField]
        [DetailViewItem(IsEnabled = false)]
        public decimal GMP { get; set; }

        [Display(Name ="Commission Amount")]
        [DatabaseField]
        [DetailViewItem(IsEnabled = false,strFormat ="###.##")]
        public decimal CommissionAmount { get; set; }

        [DataLookUp]
        [Display(Name="Status")]
        [DatabaseField(Name = "FilingStatusRefNo", RefModel = typeof(FilingStatus), RefField = "Description", RefAlias = "FS", RefTableAlias = "FS")]
        [ListViewColumn]
        [DetailViewItem(IsEnabled=false)]
        public int FilingStatusRefNo { get; set; }

        [Display(Name = "Processed Date")]
        [DatabaseField]
        [ListViewColumn]
        [DetailViewItem(IsEnabled = false)]
        public DateTime DateTransact { get; set; }

        [DetailViewItem(TabName = "Commission Summary Per Service Type")]
        [DBCollection(ForeignKey = "CommissionRefNo", ForeignKeyValue = "ID", ModelNo = "3310")]
        public List<CommissionDetails> CommissionDetails { get; set; }

        [DetailViewItem(TabName = "Details")]
        [DBCollection(ForeignKey = "CommissionRefNo", ForeignKeyValue = "ID", ModelNo = "3340")]
        public List<CommissionDetailsDetails> CommissionDetailsDetails { get; set; }

        [DetailViewItem(TabName = "Incentives")]
        [DBCollection(ForeignKey = "CommissionRefNo", ForeignKeyValue = "ID", ModelNo = "3330")]
        public List<CommissionIncentives> CommissionIncentives { get; set; }

        [DetailViewItem(TabName = "Cost")]
        [DBCollection(ForeignKey = "CommissionRefNo", ForeignKeyValue = "ID", ModelNo = "3320")]
        public List<CommissionCost> CommissionCost { get; set; }
    }
}