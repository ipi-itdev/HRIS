using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [DatabaseTable(Name = "GEN_Gender_M", PKeyName = "GenderRefNo")]
    public class Gender : BaseObject
    {
      [DatabaseField]
      [ListViewColumn]
      [DetailViewItem]
      public string Code {get; set;}

      [DatabaseField(IsRequired=true)]
      [ListViewColumn]
      [DetailViewItem(IsTextArea=true)]
      public string Description {get; set;}
    }
}