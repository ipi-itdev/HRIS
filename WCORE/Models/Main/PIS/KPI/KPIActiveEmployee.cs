using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "KPI Internal Employee", SubName = "Active")]
    [DatabaseTable(Name = "dbo.PIS_Employee_U", ViewName = "dbo.fKPIActiveEmployee(@User)", PKeyName = "EmployeeRefNo")]
    public class KPIActiveEmployee : BaseObject
    {

        [DatabaseField(AllowUpdate = false)]
        public int EmployeeRefNo { get; set; }

        [Display(Name = "Employee Name")]
        [DatabaseField(AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn(Width = 150)]
        public string Description { get; set; }
    }
}