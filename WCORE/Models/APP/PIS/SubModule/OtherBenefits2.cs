using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [Caption(Name = "Other Benefits2")]
    [MenuDescription(Name = "Other Benefits2")]
    [DatabaseTable(Name = "PIS_EmploymentInfo_U")]
    public class OtherBenefits2 : BaseObject
    {
  
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(IsTextArea = true)]
        [ListViewColumn]
        public bool HOLTag { get; set; }

        [ListViewColumn]
        [DetailViewItem]
        [DatabaseField]
        public bool TaxTag { get; set; }

        [DatabaseField(IsRequired = true)]
        [DetailViewItem(IsTextArea = true)]
        [ListViewColumn]
        public bool SEPTag { get; set; }

        [DatabaseField(IsRequired = true)]
        [DetailViewItem(IsTextArea = true)]
        [ListViewColumn]
        public bool w13thMonth { get; set; }

        [DatabaseField(IsRequired = true)]
        [DetailViewItem(IsTextArea = true)]
        [ListViewColumn]
        public int SIL { get; set; }

        [DatabaseField(IsRequired = true)]
        [DetailViewItem(IsTextArea = true)]
        [ListViewColumn]
        public double AddtlPaidLeaves { get; set; }

        [DatabaseField(IsRequired = true)]
        [DetailViewItem(IsTextArea = true)]
        [ListViewColumn]
        public bool APLProRata { get; set; }

        [DatabaseField(IsRequired = true)]
        [DetailViewItem(IsTextArea = true)]
        [ListViewColumn]
        public int HMODC { get; set; }

        [DatabaseField(IsRequired = true)]
        [DetailViewItem(IsTextArea = true)]
        [ListViewColumn]
        public int HMOAmount { get; set; }

        [DatabaseField(IsRequired = true)]
        [DetailViewItem(IsTextArea = true)]
        [ListViewColumn]
        public double OTAssumption { get; set; }
    }
}