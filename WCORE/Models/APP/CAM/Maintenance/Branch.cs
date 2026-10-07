using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "Rate Basis")]
    [DatabaseTable(Name = "CAM_Branch", PKeyName = "ID")]
    public class Branch : BaseObject
    {
        [DatabaseField]
        public int ClientAccountRefNo { get; set; }

        [DetailViewItem(IsTextArea=true)]
        [DatabaseField(IsRequired = true, IsUnique = true)]
        [ListViewColumn(Width =150)]
        public string Description { get; set; }

        [Display(Name="Address")]
        [DetailViewItem(IsTextArea = true,Column=2)]
        [DatabaseField(IsRequired = true, IsUnique = true)]
        [ListViewColumn(Width = 150)]
        public string ClientAddress { get; set; }
    }
}