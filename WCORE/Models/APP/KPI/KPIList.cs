using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WCORE.Utility;

namespace WCORE.Models
{

    [MenuDescription(Name = "KPI")]
    [DatabaseTable(Name = "PIS_PerfIndicatorList")]

    public class KPIList : BaseObject
    {
        //[DatabaseField()]
        //public int ID { get; set; }

        [Display(Name = "KPI Group Name")]
        [DatabaseField(IsRequired = true)]
        [ListViewColumn]
        [DetailViewItem(IsTextArea = true)]
        public string Description { get; set; }

        //[Display(Name = "Scorecard")]
        ////[DatabaseField(IsRequired = true)]
        //[DataLookUp]
        //[DatabaseField(IsRequired = true, Name = "ID", RefModel = typeof(KPIScoreCard), RefField = "Description", RefAlias = "SYS", RefTableAlias = "SY")]
        ////[ListViewColumn]
        //[DetailViewItem]
        //public int ScorecardPercentageRefNo { get; set; }

        //[Display(Name = "IsForManager")]
        //[DatabaseField(IsRequired = true)]
        //[ListViewColumn]
        //[DetailViewItem]
        //public bool IsForManager { get; set; }

        //[Display(Name = "Output")]
        //[DatabaseField]
        //[ListViewColumn]
        //[DetailViewItem]
        //public decimal KPIOutput { get; set; }
    }
}