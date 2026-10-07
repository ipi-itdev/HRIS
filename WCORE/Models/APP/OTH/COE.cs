using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name="COE")]
    [DatabaseTable(Name = "PIS_COERequest_U")]
    public class COE : BaseObject
    {
      [DataLookUp]
      [Display(Name = "Employee")]
      [DatabaseField(IsRequired = true, RefModel = typeof(AllEmployee), RefField = "Description", RefTableAlias = "Emp", Name = "EmployeeRefNo", RefAlias = "Sig")]
      [DetailViewItem]
      [ListViewColumn]
      public int EmployeeRefNo {get; set;}

      [Display(Name = "Requested Date")]
      [DatabaseField(IsRequired = true)]
      [ListViewColumn]
      [DetailViewItem(strFormat = "mm/dd/yyyy")]
      public DateTime RequestedDate { get; set; }

      [Display(Name = "Issued Date")]
      [DatabaseField]
      [ListViewColumn]
      [DetailViewItem(strFormat = "mm/dd/yyyy")]
      public DateTime IssuedDate { get; set; }

      [DataLookUp]
      [Display(Name="COE Template")]
      [DatabaseField(IsRequired = true, Name = "COETemplateRefNo", RefModel = typeof(COETemplate), RefField = "Description", RefAlias = "COET", RefTableAlias = "COETemp")]
      [DetailViewItem]
      [ListViewColumn]
      public int COETemplateRefNo { get; set; }

      [DataLookUp]
      [Display(Name = "Filing Status")]
      [DatabaseField(IsRequired = true, Name = "FilingStatusRefNo", RefModel = typeof(FilingStatus), RefField = "Description", RefAlias = "FS", RefTableAlias = "FS")]
      public int FilingStatusRefNo { get; set; }

      [DatabaseField]
      [DetailViewItem(IsTextArea = true)]
      [ListViewColumn]
      public string Remarks { get; set; }
    }
}