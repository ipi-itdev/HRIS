using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [DatabaseTable(Name = "VIEW_PIS_ContractType",PKeyName="ID")]
    public class ContractType : BaseObject
    {
      [DatabaseField(IsRequired=true)]
      [ListViewColumn]
      [DetailViewItem(IsTextArea=true)]
      public string Description {get; set;}
    }
}