using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "Employee")]
    [DatabaseTable(Name = "PIS_KPIAssigmentDetails", ViewName = "dbo.fKAssignedTo()", PKeyName = "KPIAssignmentRefNo")]

    public class KPIAssignedTo : BaseObject
    {
        ////[DatabaseField()]
        ////public int EmployeeRefNo { get; set; }

        [Display(Name = "Employee Number")]
        [DatabaseField]
        [ListViewColumn]
        [DetailViewItem(IsEnabled = false, Column = 2)]
        public string EmployeeNumber { get; set; }

        [Display(Name = "Employee Name")]
        [DatabaseField(AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn]
        public string Fullname { get; set; }
    }
}