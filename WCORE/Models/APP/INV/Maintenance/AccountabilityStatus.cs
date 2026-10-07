using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name="Item Status")]
    [DatabaseTable(Name = "INVAIStatus", PKeyName = "ID")]
    public class AccountabilityStatus : BaseObject
    {
      [DatabaseField]
      [DetailViewItem(IsTextArea = true)]
      [ListViewColumn]
      public string Description { get; set; }
    }
}