using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "Client")]
    [DatabaseTable(Name = "dbo.fKPIClientSelect(@User)", ViewName = "dbo.fKPIClientSelect(@User)", PKeyName = "jobPositionRefNo")]
    public class KPIClientSelect : BaseObject
    {
        [DetailViewItem]
        [DatabaseField(IsRequired = true, IsUnique = true)]
        [ListViewColumn(Width = 20)]
        public string Code { get; set; }

        [DetailViewItem(IsTextArea = true)]
        [DatabaseField(IsRequired = true, IsUnique = true)]
        [ListViewColumn(Width = 150)]
        public string Description { get; set; }
    }
}