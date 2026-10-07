using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "ReasonForSeperation")]
    [DatabaseTable(Name = "GEN_ReasonForSeperation_M", PKeyName = "ReasonForSeperationRefNo")]
    public class ReasonForSeperation : BaseObject
    {
        [DetailViewItem(IsTextArea = true)]
        [DatabaseField(IsRequired = true, IsUnique = true)]
        [ListViewColumn]
        public string Description { get; set; }

    }
}