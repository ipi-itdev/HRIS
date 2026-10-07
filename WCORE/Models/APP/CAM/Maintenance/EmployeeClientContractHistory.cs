using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "Employee Client Contract")]
    [DatabaseTable(Name = "CAM_ECAR", PKeyName = "ID")]
    public class EmployeeClientContractHistory : BaseObject
    {
        [DatabaseField]
        public int ClientAccountRefNo { get; set; }

        [Display(Name = "Employee")]
        [DetailViewItem]
        [ListViewColumn]
        [DatabaseField(IsRequired = true, RefModel = typeof(ActiveFloatingEmployee), RefField = "Description", RefTableAlias = "Emp", Name = "EmployeeRefNo", RefAlias = "Emp")]
        public int EmployeeRefNo { get; set; }

        [Display(Name="Start Date")]
        [ListViewColumn]
        [DetailViewItem]
        [DatabaseField]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [ListViewColumn]
        [DetailViewItem]
        [DatabaseField]
        public DateTime EndDate { get; set; }
    }
}