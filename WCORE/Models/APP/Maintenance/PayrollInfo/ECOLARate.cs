using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "ECOLA Rate")]
    [DatabaseTable(Name = "PAY_ECOLARate_M", PKeyName = "EcolaRateRefNo")]
    public class EcolaRate : BaseObject
    {
        [DatabaseField]
        [ListViewColumn]
        [DetailViewItem]
        public string Code { get; set; }

        [DatabaseField(IsRequired = true,IsUnique =true)]
        [ListViewColumn]
        [DetailViewItem(IsTextArea = true)]
        public string Description { get; set; }

        [Display(Name = "Amount")]
        [DatabaseField(IsRequired = true)]
        [ListViewColumn]
        [DetailViewItem]
        public decimal EcolaAmount { get; set; }
    }
}