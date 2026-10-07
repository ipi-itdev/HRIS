using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "KPI Add Change 2")]
    [DatabaseTable(Name = "View_KPI_Add_Change_2", ViewName = "View_KPI_Add_Change_2", PKeyName = "ID3")]
    public class KPIAddChange2 : BaseObject
    {
        [ListViewColumn]
        [DetailViewItem(IsTextArea = true)]
        public string Description { get; set; }
    }
}