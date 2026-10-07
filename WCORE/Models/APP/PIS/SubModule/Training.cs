using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name="Employee Training")]
    [DatabaseTable(Name = "PIS_EmployeeTraining_U")]
    public class Training : BaseObject
    {
      [DatabaseField]
      public int EmployeeRefNo {get; set;}

      [Display(Name = "Program Name")]
      [DatabaseField(IsRequired = true)]
      [ListViewColumn]
      [DetailViewItem(IsTextArea=true)]
      public string ProgramName { get; set; }

      [Display(Name = "Training Dates")]
      [DatabaseField(IsRequired=true)]
      [DetailViewItem(IsDateRange = true)]
      public string TraningDates { get; set; }

      [Display(Name = "Training Provider")]
      [DatabaseField(IsRequired = true)]
      [ListViewColumn]
      [DetailViewItem(Column = 2)]
      public string Facilitator { get; set; }

      [Display(Name = "Resource Speaker")]
      [DatabaseField(IsRequired = true)]
      [ListViewColumn]
      [DetailViewItem(Column = 2)]
      public string ResourceSpeaker { get; set; }

      [DataLookUp]
      [Display(Name = "Job Band")]
      [DatabaseField(Name = "JobBandRefNo", RefModel = typeof(JobBand), RefField = "Description", RefAlias = "JobBand", RefTableAlias = "JB")]
      [DetailViewItem(Column = 2)]
      public int JobBandRefNo { get; set; }
    }
}