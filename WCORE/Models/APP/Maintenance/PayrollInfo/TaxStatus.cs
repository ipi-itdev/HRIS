using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "Tax Status")]
    [DatabaseTable(Name = "GEN_TaxStatus_M", PKeyName = "TaxStatusRefNo")]
    public class TaxStatus : BaseObject
    {

        [DetailViewItem]
        [DatabaseField(IsRequired = true, IsUnique = true)]
        [ListViewColumn]
        public string Code { get; set; }

        [DetailViewItem(IsTextArea = true)]
        [DatabaseField(IsRequired = true, IsUnique = true)]
        [ListViewColumn]
        public string Description { get; set; }

        [DetailViewItem]
        [Display(Name = "No Of Dependent")]
        [DatabaseField]
        [ListViewColumn]
        public int NoOfDefendent { get; set; }

        [DetailViewItem]
        [Display(Name = "Tax Percent")]
        [DatabaseField]
        [ListViewColumn]
        public decimal TaxExempPerc { get; set; }

        [DetailViewItem(IsEnabled = false)]
        [Display(Name = "Exemption")]
        [DatabaseField]
        [ListViewColumn]
        public int PersonalExemption { get; set; }
    }
}