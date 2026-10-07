using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "KPI Add Change 3")]
    [DatabaseTable(Name = "View_KPI_Add_Change_3", ViewName = "View_KPI_Add_Change_3", PKeyName = "ID4")]
    public class KPIAddChange3 : BaseObject
    {
        //[ListViewColumn]
        [DetailViewItem(IsTextArea = true)]
        public string Description { get; set; }
    }
}