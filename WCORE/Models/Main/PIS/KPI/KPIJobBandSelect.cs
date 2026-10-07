using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "Job Band")]
    [DatabaseTable(Name = "PIS_JobBand_U", ViewName = "dbo.fKPIJobBandSelect(@User)", PKeyName = "JobBandRefNo")]
    public class KPIJobBandSelect : BaseObject
    {
        [DetailViewItem(IsTextArea = true)]
        [DatabaseField(IsRequired = true, IsUnique = true)]
        [ListViewColumn(Width = 150)]
        public string Description { get; set; }
    }
}