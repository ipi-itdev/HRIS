using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "Client Call")]
    [DatabaseTable(Name = "CAM_CAR", PKeyName = "ID")]
    public class ClientAccountHistory : BaseObject
    {
        [DatabaseField]
        public int ClientAccountRefNo { get; set; }

        [Display(Name="Start Date")]
        [ListViewColumn]
        [DetailViewItem]
        [DatabaseField]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [ListViewColumn]
        [DetailViewItem]
        [DatabaseField]
        public DateTime EndDate { get; set; }

        [Display(Name = "Is Origin")]
        [ListViewColumn]
        [DetailViewItem]
        [DatabaseField]
        public bool IsOrigin { get; set; }
    }
}