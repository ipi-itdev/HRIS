using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "Barangay")]
    [DatabaseTable(Name = "GEN_Barangay_M", PKeyName = "BarangayRefNo")]
    //[DatabaseTable(Name = "View_Barangay", PKeyName = "BarangayRefNo")]
    public class Barangay : BaseObject
    {
        //[DataLookUp]
        //[Display(Name = "city/Municipality")]
        //[DatabaseField(IsRequired = true, RefModel = typeof(Province), RefField = "Description", RefTableAlias = "City", Name = "MunicipalityRefNo", RefAlias = "City")]
        //[DetailViewItem]
        //[ListViewColumn]
        //public int MunicipalityRefNo { get; set; }

        [DetailViewItem(IsTextArea = true)]
        [DatabaseField(IsRequired = true, IsUnique = true)]
        [ListViewColumn]
        public string Description { get; set; }
    }
}