using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "KPI Add Change")]
    [DatabaseTable(Name = "View_KPI_Add_Change", ViewName = "View_KPI_Add_Change", PKeyName = "ID2")]
    public class KPIAddChange : BaseObject
    {
        [ListViewColumn]
        [DetailViewItem(IsTextArea = true)]
        public string Description { get; set; }
    }
}