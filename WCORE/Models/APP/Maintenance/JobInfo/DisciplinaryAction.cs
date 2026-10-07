using System;
using System.Linq;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "DisciplinarAction")]
    [DatabaseTable(Name = "GEN_DisciplinaryAction_M", PKeyName = "DisciplinaryActionRefNo", SeqBy = "Seq")]
    public class DisciplinaryAction : BaseObject
    {
        [DetailViewItem(IsTextArea = true)]
        [DatabaseField(IsRequired = true, IsUnique = true)]
        [ListViewColumn]
        public string Description { get; set; }
    }
}