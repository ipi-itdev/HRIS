using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [Caption(Name = "Highest Education")]
    [MenuDescription(Name = "Education")]
    [DatabaseTable(Name = "PIS_HighestEducationAudit_U", PKeyName = "ID")]
    public class HighestEducationAudit : BaseObject
    {
        [DatabaseField(AllowUpdate = false)]
        public int EmployeeRefNo { get; set; }

        [DatabaseField(IsRequired = true)]
        [DetailViewItem(Column = 2)]
        [ListViewColumn]
        public string YearGraduated { get; set; }

        [DatabaseField(IsRequired = true)]
        [DetailViewItem(IsTextArea = true)]
        [ListViewColumn]
        public string School { get; set; }

        [DatabaseField(IsRequired=true)]
        [DetailViewItem(IsTextArea = true, Column = 2)]
        [ListViewColumn]
        public string Course { get; set; }
    }
}