using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "Other Cost")]
    [DatabaseTable(Name = "PIS_EmployeeOtherBenefits_U", PKeyName = "EmployeeRefNo", ViewName = "PIS_EmployeeCost")]
    public class OtherCost : BaseObject
    {
        [DatabaseField]
        public int EmployeeRefNo { get; set; }

        [DatabaseField(IsRequired=true)]
        [DetailViewItem(IsTextArea=true)]
        [ListViewColumn]
        public string Description { get; set; }

        [Display(Name="Cost")]
        [ListViewColumn]
        [DetailViewItem]
        [DatabaseField]
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

        [DatabaseField(DefaultValue="1")]
        public bool IsCost { get; set; }
    }
}