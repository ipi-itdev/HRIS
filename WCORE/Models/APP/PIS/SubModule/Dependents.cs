using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name="Dependents")]
    [DatabaseTable(Name = "PIS_EmployeeDependents_U")]
    public class Dependents : BaseObject
    {
      
      [Display(Name = "Dependents Name")]
      [DatabaseField(IsRequired = true,IsProperCase=true)]
      [ListViewColumn]
      [DetailViewItem]
      public string Description {get; set;}

      [Display(Name = "Dependents Relationship")]
      [DatabaseField(IsRequired = true, IsProperCase = true)]
      [ListViewColumn]
      [DetailViewItem]
      public string Relationship { get; set; }

      [DatabaseField]
      public int EmployeeRefNo {get; set;}

      [Display(Name = "Dependents Birth Date")]
      [DatabaseField(IsRequired = true)]
      [ListViewColumn]
      [DetailViewItem(Column = 2, strFormat = "mm/dd/yyyy")]
      public DateTime BirthDate { get; set; }

      [Display(Name = "Dependents Age")]
      [DatabaseField(AllowInsert = false, AllowUpdate = false)]
      [DetailViewItem(IsEnabled = false, Column = 2)]
      public int Age { get; set; }

      [Display(Name = "PWD")]
      [DatabaseField]
      [ListViewColumn]
      [DetailViewItem(Column=2)]
      public Boolean IsPWD { get; set; }
    }
}