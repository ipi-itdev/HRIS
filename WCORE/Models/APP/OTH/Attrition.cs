using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "Attrition")]
    [DatabaseTable(Name = "PIS_Attrition_U", ViewName = "dbo.fSelectAttrition(@User)")]
    public class Attrition : BaseObject
    {

        [DataLookUp]
        [Display(Name = "Employee")]
        [DatabaseField(IsRequired = true, RefModel = typeof(ActiveFloatingEmployee), RefField = "Description", RefTableAlias = "Emp", Name = "EmployeeRefNo", RefAlias = "Sig")]
        [DetailViewItem]
        [ListViewColumn]
        public int EmployeeRefNo {get; set;}

        [Display(Name = "Last Date of Employment")]
        [DatabaseField(IsRequired = true)]
        [ListViewColumn]
        [DetailViewItem(Column = 2, strFormat = "mm/dd/yyyy")]
        public DateTime LastDateofEmployment { get; set; }

        [DataLookUp]
        [Display(Name = "Reason")]
        [DatabaseField(IsRequired = true, RefModel = typeof(ReasonForSeperation), RefField = "Description", RefTableAlias = "RS", Name = "ReasonForSeperationRefNo", RefAlias = "RS")]
        [DetailViewItem]
        [ListViewColumn]
        public int ReasonForSeparationRefNo { get; set; }

        [Display(Name ="Remarks")]
        [DatabaseField]
        [ListViewColumn]
        [DetailViewItem(IsTextArea = true,Column=2)]
        public string ReasonForSeparation { get; set; }

        [Display(Name = "Reason of Cancellation")]
        [DatabaseField]
        [ListViewColumn]
        [DetailViewItem(IsTextArea = true, Column = 2)]
        public string Remarks { get; set; }

        [Display(Name = "Eligible for Re-Hire")]
        [DatabaseField]
        [ListViewColumn]
        [DetailViewItem]
        public bool IsForReHire { get; set;  }
    }
}