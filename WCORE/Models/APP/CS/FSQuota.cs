using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;
using WCORE.Models; 

namespace WCORE.Models
{
    [MenuDescription(Name = "FS Quota")]
    [DatabaseTable(Name = "CS_FSQuota_U")]
    public partial class FSQuota : BaseObject
    {
        [DataLookUp]
        [Display(Name = "Department")]
        [DatabaseField(IsRequired = true, Name = "DepartmentRefNo", RefModel = typeof(Department), RefField = "Description", RefAlias = "Dep", RefTableAlias = "Dep")]
        [ListViewColumn]
        [DetailViewItem]
        public int DepartmentRefNo { get; set; }

        [DatabaseField(IsRequired = true)]
        [ListViewColumn]
        [DetailViewItem]
        public int Year { get; set; }

        [Display(Name ="Annual Quota")]
        [DatabaseField(IsRequired=true)]
        [DetailViewItem]
        [ListViewColumn]
        public decimal Amount { get; set; }

        [Display(Name = "FS Commission")]
        [DatabaseField]
        [DetailViewItem(IsEnabled =false)]
        [ListViewColumn]
        public decimal FSCommissionAmount { get; set; }

        [Display(Name = "Personal Commission")]
        [DatabaseField]
        [DetailViewItem(IsEnabled = false)]
        [ListViewColumn]
        public decimal PersonalCommission { get; set; }

        [Display(Name = "Late Payments")]
        [DatabaseField]
        [DetailViewItem(IsEnabled = false)]
        [ListViewColumn]
        public decimal LatePayments { get; set; }

        [Display(Name = "Total Commission")]
        [DatabaseField]
        [DetailViewItem(IsEnabled = false)]
        [ListViewColumn]
        public decimal TotalCommission { get; set; }

        [DetailViewItem(TabName = "Details")]
        [DBCollection(ForeignKey = "FSQuotaRefNo", ForeignKeyValue = "ID", ModelNo = "3110")]
        public List<FSQuotaDetails> FSQuotaDetails { get; set; }
    }
}