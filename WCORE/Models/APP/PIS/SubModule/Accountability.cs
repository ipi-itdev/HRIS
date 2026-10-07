using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name="Employee Accountability")]
    [DatabaseTable(Name = "PIS_EmployeeAccountability_U")]
    public class Accountability : BaseObject
    {
      [DatabaseField]
      public int EmployeeRefNo {get; set;}

      [DatabaseField(IsRequired = true,IsProperCase=true)]
      [ListViewColumn]
      [DetailViewItem(IsTextArea=true)]
      public string Description { get; set; }

      [Display(Name = "Date Issued")]
      [DatabaseField(IsRequired = true)]
      [ListViewColumn]
      [DetailViewItem(Column = 2, strFormat = "mm/dd/yyyy")]
      public DateTime DateIssued { get; set; }

      [Display(Name = "Date Returned")]
      [DatabaseField]
      [ListViewColumn]
      [DetailViewItem(Column = 2, strFormat = "mm/dd/yyyy")]
      public DateTime DateReturned { get; set; }

      [DatabaseField]
      [ListViewColumn]
      [DetailViewItem(IsTextArea = true,Column=2)]
      public string Remarks { get; set; }
    }
}