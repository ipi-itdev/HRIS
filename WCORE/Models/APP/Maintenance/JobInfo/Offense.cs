using System;
using System.Linq;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name="Offense")]
    [DatabaseTable(Name = "GEN_Offense_M", PKeyName = "OffenseRefNo", SeqBy = "Seq")]
    public class Offense : BaseObject
    {

        [DetailViewItem(IsTextArea = true)]
        [DatabaseField(IsUnique =true,IsRequired =true)]
        [ListViewColumn]
        public string Description { get; set; }

    }
}