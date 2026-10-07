using System;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "Other Benefits")]
    [DatabaseTable(Name = "PIS_PARBenefits", ViewName = "PARBenefits")]
    public class PARBenefits : BaseObject
    {
        [DatabaseField]
        public int PARRefNo { get; set; }

        [DatabaseField(IsRequired=true)]
        [DetailViewItem(IsTextArea=true)]
        [ListViewColumn]
        public string Description { get; set; }

        [DatabaseField(IsRequired = true)]
        [ListViewColumn]
        [DetailViewItem]
        public decimal Amount { get; set; }

        [DataLookUp]
        [Display(Name = "Terms")]
        [DatabaseField(IsRequired = true, Name = "TermsRefNo", RefModel = typeof(Terms), RefField = "Description", RefAlias = "PTerms", RefTableAlias = "PT")]
        [DetailViewItem(Column=2)]
        [ListViewColumn]
        public int TermsRefNo { get; set; }
        
        [Display(Name="Start Date")]
        [DatabaseField]
        [DetailViewItem(Column=2,strFormat="mm/dd/yyyy")]
        [ListViewColumn]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DatabaseField]
        [DetailViewItem(Column = 2, strFormat = "mm/dd/yyyy")]
        [ListViewColumn]
        public DateTime EndDate { get; set; }

        [Display(Name = "New Benefits?")]
        [DatabaseField]
        [DetailViewItem(Column = 2)]
        [ListViewColumn]
        public bool IsNew { get; set; }

        [DatabaseField]
        public bool IsCost { get; set; }

    }
}