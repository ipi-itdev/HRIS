using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "Other Cost")]
    [DatabaseTable(Name = "PIS_PARBenefits", ViewName = "PARCost")]
    public class PARCost : BaseObject
    {
        [DatabaseField]
        public int PARRefNo { get; set; }

        [DatabaseField(IsRequired = true)]
        [DetailViewItem(IsTextArea = true)]
        [ListViewColumn]
        public string Description { get; set; }

        [Display(Name = "Cost")]
        [DatabaseField(IsRequired = true)]
        [ListViewColumn]
        [DetailViewItem]
        public Decimal Amount { get; set; }

        [DataLookUp]
        [Display(Name = "Terms")]
        [DatabaseField(IsRequired = true, Name = "TermsRefNo", RefModel = typeof(Terms), RefField = "Description", RefAlias = "PTerms", RefTableAlias = "PT")]
        [DetailViewItem(Column = 2)]
        [ListViewColumn]
        public int TermsRefNo { get; set; }

        [Display(Name = "Start Date")]
        [DatabaseField]
        [DetailViewItem(Column = 2, strFormat = "mm/dd/yyyy")]
        [ListViewColumn]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DatabaseField]
        [DetailViewItem(Column = 2, strFormat = "mm/dd/yyyy")]
        [ListViewColumn]
        public DateTime EndDate { get; set; }

        [Display(Name = "New Cost?")]
        [DatabaseField]
        [DetailViewItem(Column = 2)]
        [ListViewColumn]
        public bool IsNew { get; set; }

        [DatabaseField(DefaultValue="1", AllowUpdate = false)]
        public bool IsCost { get; set; }
    }
}