using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "Cost Center")]
    [DatabaseTable(Name = "BIL_CostCenter_U",PKeyName="ClientAccountRefNo")]
    public class CostCenter : BaseObject
    {
        [DetailViewItem(IsTextArea=true)]
        [DatabaseField(IsRequired = true)]
        [ListViewColumn(Width =100)]
        public string Code { get; set; }

        [Display(Name = "Contact Person")]
        [DetailViewItem]
        [DatabaseField]
        [ListViewColumn]
        public string ContactPerson { get; set; }

        [Display(Name = "Contact Person Position")]
        [DetailViewItem]
        [DatabaseField]
        public string ContactPersonPosition { get; set; }

        [Display(Name = "Contact Person Mobile")]
        [DetailViewItem]
        [DatabaseField]
        public string ContactPersonMobile { get; set; }


        [DataLookUp(WithAdd = true)]
        [Display(Name = "Absences Rate Basis")]
        [DetailViewItem]
        [ListViewColumn]
        [DatabaseField(IsRequired = true, RefModel = typeof(RateBasis), RefField = "Description", RefTableAlias = "ARB", Name = "RateBasisRefNo", RefAlias = "ARB")]
        public int AbsencesRateBasisRefNo { get; set; }

        [DataLookUp(WithAdd = true)]
        [Display(Name = "OT Rate Basis")]
        [DetailViewItem]
        [ListViewColumn]
        [DatabaseField(IsRequired = true, RefModel = typeof(RateBasis), RefField = "Description", RefTableAlias = "ORB", Name = "RateBasisRefNo", RefAlias = "ORB")]
        public int OTRateBasisRefNo { get; set; }

        [Display(Name = "Is Non-Vat")]
        [DetailViewItem]
        [DatabaseField]
        public bool IsNonVat { get; set; }

        [DetailViewItem]
        [DatabaseField]
        public string Address { get; set; }

        [Display(Name = "Is Fixed")]
        [DetailViewItem]
        [DatabaseField]
        public bool IsFixed { get; set; }

    }
}