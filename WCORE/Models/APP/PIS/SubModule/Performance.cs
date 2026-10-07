using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name="Performance")]
    [DatabaseTable(Name = "PIS_KPIAssigmentDetails", ViewName = "PIS_EmployeeEvaluation")]
    public class Performance : BaseObject
    {
      [Display(Name="Date From")]
      [DatabaseField(NotInTable=true)]
      [ListViewColumn]
      public string Purpose { get; set; }
      
      [Display(Name="Start Date")]
      [DatabaseField(NotInTable = true)]
      [ListViewColumn]
      public DateTime StartDate { get; set; }

      [Display(Name = "End Date")]
      [DatabaseField(NotInTable = true)]
      [ListViewColumn]
      public DateTime EndDate { get; set; }

      [DatabaseField(NotInTable = true)]
      [ListViewColumn]
      public string Supervisor { get; set; }

      [DatabaseField(NotInTable = true)]
      [ListViewColumn]
      public decimal Rating { get; set; }

      [DatabaseField(NotInTable = true)]
      [ListViewColumn]
      public string Interpretation { get; set; }

      [DatabaseField]
      [ListViewColumn]
      [DetailViewItem(IsTextArea = true, Column = 2)]
      public string Remarks { get; set; }
    }
}