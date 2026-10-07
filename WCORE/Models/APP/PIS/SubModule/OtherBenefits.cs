using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [Caption(Name = "Other Benefits")]
    [MenuDescription(Name = "Other Benefits")]
    [DatabaseTable(Name = "PIS_EmployeeOtherBenefits_U", PKeyName = "EmployeeRefNo", ViewName = "PIS_EmployeeBenefits")]
    public class OtherBenefits : BaseObject
    {
        [DatabaseField]
        public int EmployeeRefNo { get; set; }

        [DatabaseField(IsRequired=true)]
        [DetailViewItem(IsTextArea=true)]
        [ListViewColumn]
        public string Description { get; set; }

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

        [DatabaseField]
        public bool IsCost { get; set; }
    }
}