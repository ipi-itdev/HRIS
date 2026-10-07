using System;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "Commission Rate")]
    [DatabaseTable(Name = "CS_CommissionRate_U")]
    public class CommissionRate : BaseObject
    {
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(IsTextArea=true)]
        [ListViewColumn]
        public String Description { get; set; }

        [Display(Name="GM From")]
        [DatabaseField(IsRequired=true)]
        [DetailViewItem]
        [ListViewColumn]
        public Decimal GMFrom { get; set; }

        [Display(Name = "GM To")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem]
        [ListViewColumn]
        public Decimal GMTo { get; set; }

        [Display(Name = "YTD ACH From")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem]
        [ListViewColumn]
        public Decimal YTDAchievementFrom { get; set; }

        [Display(Name = "YTD ACH To")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem]
        [ListViewColumn]
        public Decimal YTDAchievementTo { get; set; }

        [DatabaseField(IsRequired = true)]
        [DetailViewItem]
        [ListViewColumn]
        public Decimal Value { get; set; }

        [Display(Name = "Is For MR?")]
        [DatabaseField]
        [DetailViewItem]
        [ListViewColumn]
        public bool IsForMR { get; set; }

        [Display(Name = "Is For MM?")]
        [DatabaseField]
        [DetailViewItem]
        [ListViewColumn]
        public bool IsForMM { get; set; }

        [Display(Name = "Is For FS?")]
        [DatabaseField]
        [DetailViewItem]
        [ListViewColumn]
        public bool IsForFS { get; set; }
    }
}