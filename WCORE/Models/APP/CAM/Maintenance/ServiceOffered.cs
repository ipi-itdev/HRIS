using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "Service Offered")]
    [DatabaseTable(Name = "CAM_ServiceOffered", PKeyName = "ID")]
    public class ServiceOffered : BaseObject
    {
        [DetailViewItem]
        [DatabaseField(IsRequired = true)]
        [ListViewColumn(Width = 150)]
        public string Code { get; set; }

        [DetailViewItem(IsTextArea=true)]
        [DatabaseField(IsRequired = true)]
        [ListViewColumn(Width =150)]
        public string Description { get; set; }
    }
}