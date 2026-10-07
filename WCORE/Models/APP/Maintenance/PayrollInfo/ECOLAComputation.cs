using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "ECOLA Computation")]
    [DatabaseTable(Name = "PAY_ECOLAComputation_F", PKeyName = "EcolaComputationRefNo")]
    public class ECOLAComputation : BaseObject
    {
        [DatabaseField]
        [ListViewColumn]
        [DetailViewItem]
        public string Code { get; set; }

        [DatabaseField(IsRequired=true,IsUnique = true)]
        [ListViewColumn]
        [DetailViewItem(IsTextArea=true)]
        public string Description { get; set; }
    }
}