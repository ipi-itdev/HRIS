using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "City")]
    [DatabaseTable(Name = "GEN_Municipality_M", PKeyName = "MunicipalityRefNo")]
    //[DatabaseTable(Name = "View_Municipality", PKeyName = "MunicipalityRefNo")]
    public class City : BaseObject
    {
        //[DataLookUp]
        //[Display(Name="Province")]
        //[DatabaseField(IsRequired = true, RefModel = typeof(Province), RefField = "Description", RefTableAlias = "Prov", Name = "ProvinceRefNo", RefAlias = "Prov")]
        //[DetailViewItem]
        //[ListViewColumn]
        //public int ProvinceRefNo { get; set; }

        [DetailViewItem(IsTextArea = true)]
        [DatabaseField(IsRequired = true, IsUnique = true)]
        [ListViewColumn]
        public string Description { get; set; }
    }
}