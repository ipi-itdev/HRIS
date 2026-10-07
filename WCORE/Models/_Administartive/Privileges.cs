using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name="User Privileges",HasDefault=true,WOOthers=true)]
    [DatabaseTable(Name = "SYS_UserPrivileges_Detail")]
    public class Privileges :BaseObject
    {

      [Display(Name="Menu")]
      [ListViewColumn]
      [DataLookUp]
      [DetailViewItem(IsEnabled=false)]
      [DatabaseField(IsTable=true,RefModel=typeof(Menu),RefField="Description",RefAlias="Menu",RefTableAlias="M",Name="MenuRefNo")]
      public int MenuRefNo {get; set;}

      [Display(Name="View")]
      [DatabaseField]
      [ListViewColumn]
      [DetailViewItem]
      public bool AllowView { get; set; }

      [Display(Name = "New")]
      [DatabaseField]
      [ListViewColumn]
      [DetailViewItem]
      public bool AllowInsert {get; set;}

      [Display(Name = "Edit")]
      [DatabaseField]
      [ListViewColumn]
      [DetailViewItem]
      public bool AllowUpdate {get; set;}

      [Display(Name = "Cancel")]
      [DatabaseField]
      [ListViewColumn]
      [DetailViewItem]
      public bool AllowDelete {get; set;}

      [Display(Name = "Print")]
      [DatabaseField]
      [ListViewColumn]
      [DetailViewItem]
      public bool AllowPrint {get; set;}

      [Display(Name = "Approve")]
      [DatabaseField]
      [ListViewColumn]
      [DetailViewItem]
      public bool AllowApprove { get; set; }

      [DatabaseField]
      public int UserPrivilegesRefno { get; set; }
    }
}