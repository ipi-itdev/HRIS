using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "Force Leave")]
    [DatabaseTable(Name = "PORTAL_DHSForceLeave_U", ViewName = "dbo.fSelectDHSForceLeave(@User)")]
    public class ForceLeave : BaseObject
    {
        [DataLookUp]
        [Display(Name = "Employee")]
        [DatabaseField(IsRequired = true, RefModel = typeof(AllEmployee), RefField = "Description", RefTableAlias = "Emp", Name = "EmployeeRefNo", RefAlias = "Sig")]
        [DetailViewItem]
        [ListViewColumn]
        public int EmployeeRefNo {get; set;}

        [Display(Name = "Start Date")]
        [DatabaseField(IsRequired = true)]
        [ListViewColumn]
        [DetailViewItem(Column = 2, strFormat = "mm/dd/yyyy")]
        public DateTime StartDate { get; set; }
        
        [DatabaseField]
        [ListViewColumn]
        [DetailViewItem(IsTextArea = true,Column=2)]
        public string Remarks { get; set; }
    }
}