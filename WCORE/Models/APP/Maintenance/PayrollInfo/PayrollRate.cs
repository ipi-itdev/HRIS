using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "Payroll Rate")]
    [DatabaseTable(Name = "PAY_PayrollRate_M", PKeyName = "PayrollRateRefNo")]
    public class PayrollRate : BaseObject
    {
        [DatabaseField]
        [ListViewColumn]
        [DetailViewItem]
        public string Code { get; set; }

        [DatabaseField(IsRequired=true)]
        [ListViewColumn]
        [DetailViewItem(IsTextArea=true)]
        public string Description { get; set; }

        [Display(Name = "Total Days")]
        [DatabaseField(IsRequired = true)]
        [ListViewColumn]
        [DetailViewItem(Column = 2)]
        public decimal TotalDays { get; set; }

        [Display(Name="Total Months")]
        [DatabaseField(IsRequired = true)]
        [ListViewColumn]
        [DetailViewItem(Column=2)]
        public decimal TotalMonths { get; set; }
    }
}