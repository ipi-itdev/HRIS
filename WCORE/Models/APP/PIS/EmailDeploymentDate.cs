using System;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name="COE")]
    [DatabaseTable(Name = "PORTAL_Users_C", ViewName = "PIS_VW_PortalEmailDeploymentDate")]
    public class EmailDeploymentDate : BaseObject
    {
      [DataLookUp]
      [Display(Name = "Employee")]
      [DatabaseField(AllowUpdate = false,RefModel = typeof(AllEmployee), RefField = "Description", RefTableAlias = "Emp", Name = "EmployeeRefNo", RefAlias = "Sig")]
      [DetailViewItem]
      [ListViewColumn]
      public int EmployeeRefNo {get; set;}

      [DatabaseField(IsRequired = true)]
      [DetailViewItem]
      [ListViewColumn]
      public string Email { get; set; }

      [Display(Name = "Deployment Date")]
      [DatabaseField(IsRequired = true)]
      [ListViewColumn]
      [DetailViewItem(strFormat = "mm/dd/yyyy")]
      public DateTime DeploymentDate { get; set; }


    }
}