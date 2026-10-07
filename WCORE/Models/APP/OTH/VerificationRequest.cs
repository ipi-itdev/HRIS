using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name="Verification Request")]
    [DatabaseTable(Name = "PIS_VerificationRequest_U", ViewName = "dbo.fGetEmployeeVerificationRequest(1)")]
    public class VerificationRequest : BaseObject
    {
      [DetailViewItem(IsEnabled=false)]
      [ListViewColumn]
      [DatabaseField]
      public string Series { get; set; }

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
      [DetailViewItem(strFormat = "mm/dd/yyyy")]
      [ListViewColumn]
      public DateTime IssuedDate { get; set; }

      [DataLookUp]
      [Display(Name = "Verification Template")]
      [DatabaseField(IsRequired = true, Name = "VeririficationTemplateRefNo", RefModel = typeof(VerificationTemplate), RefField = "Description", RefAlias = "VET", RefTableAlias = "VET")]
      [DetailViewItem]
      [ListViewColumn]
      public int VerificationTemplateRefNo { get; set; }

      [DatabaseField]
      [DetailViewItem(IsTextArea=true)]
      [ListViewColumn]
      public string Remarks { get; set; }
    }
}