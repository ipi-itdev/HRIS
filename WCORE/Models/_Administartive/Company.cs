using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "Company")]
    [DatabaseTable(Name = "GEN_Company_M", PKeyName = "CompanyRefNo")]
    public class Company : BaseObject
    {
        [DatabaseField]
        [ListViewColumn]
        [DetailViewItem]
        public string Code { get; set; }

        [DatabaseField(IsRequired = true)]
        [ListViewColumn]
        [DetailViewItem(IsTextArea = true)]
        public string Description { get; set; }
    }
}