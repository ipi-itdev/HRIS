using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name="Supplier")]
    [DatabaseTable(Name = "dbo.INV_Supplier_F", PKeyName = "SupplierRefNo")]
    public class Supplier : BaseObject
    {

        [DetailViewItem(IsEnabled =false)]
        [DatabaseField]
        [ListViewColumn]
        public string Description { get; set; }


    }
}


