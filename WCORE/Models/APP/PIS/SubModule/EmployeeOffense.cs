using System;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [Caption(Name="Employee Offense")]
    [MenuDescription(Name="Employee Offense")]
    [DatabaseTable(Name = "PIS_EmployeeOffense_U")]
    public class EmployeeOffense : BaseObject
    {
       [DatabaseField]
       public int EmployeeRefNo {get; set;}

       [DataLookUp]
       [Display(Name = "Offense")]
       [DatabaseField(IsRequired = true , Name = "OffenseRefNo", RefModel = typeof(Offense), RefField = "Description", RefAlias = "OFNS", RefTableAlias = "OFNS")]
       [DetailViewItem]
       [ListViewColumn(Width = 200)]
       public int OffenseRefNo {get; set;}

       [DataLookUp]
       [Display(Name = "Disciplinary Action")]
       [DatabaseField(IsRequired = true, Name = "DisciplinaryActionRefNo", RefModel = typeof(DisciplinaryAction), RefField = "Description", RefAlias = "DA", RefTableAlias = "DA")]
       [DetailViewItem]
       [ListViewColumn(Width = 200)]
       public int DisciplinaryActionRefNo {get; set;}

       [Display(Name = "Date Committed")]
       [DatabaseField(IsRequired = true)]
       [DetailViewItem(Column = 2, strFormat = "mm/dd/yyyy")]
       [ListViewColumn(Width = 50)]
       public DateTime OffenseCommitedDate {get; set;}

       [Display(Name = "Suspension Dates")]
       [DatabaseField]
       [DetailViewItem(Column = 2, IsTextArea = true)]
       public string SuspensionDates { get; set; }

       [Display(Name = "Remarks")]
       [DetailViewItem(IsTextArea = true)]
       [DatabaseField]
       [ListViewColumn(Width = 200)]
       public string Remarks { get; set; }
    }
}