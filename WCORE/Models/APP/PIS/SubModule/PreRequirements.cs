using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name="Employee Pre-Employment") ]
    [DatabaseTable(Name = "PIS_PreEmploymentRequirement_U")]
    public class PreRequirements : BaseObject
    {
      [Display(Name= "Requirement Type")]
      [DataLookUp]
      [DetailViewItem(IsEnabled=false)]
      [ListViewColumn]
      [DatabaseField(Name = "ID", RefModel = typeof(PreEmpType), RefField = "Description", RefAlias = "PET", RefTableAlias = "PET")]
      public int TypeRefNo { get; set;}

      [ListViewColumn]
      [DatabaseField]
      public string Filename { get; set; }
    }
}