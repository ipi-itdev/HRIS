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

    public class KPIListManager : BaseObject
    {
        //[DatabaseField()]
        //public int ID { get; set; }

        [Display(Name = "KPI Group Name")]
        [DatabaseField(IsRequired = true)]
        [ListViewColumn]
        [DetailViewItem(IsTextArea = true)]
        public string Description { get; set; }

        [Display(Name = "Scorecard")]
        //[DatabaseField(IsRequired = true)]
        [DataLookUp]
        [DatabaseField(IsRequired = true, Name = "ID", RefModel = typeof(KPIScoreCard), RefField = "Description", RefAlias = "SYS", RefTableAlias = "SY")]
        //[ListViewColumn]
        [DetailViewItem]
        public int ScorecardPercentageRefNo { get; set; }

        //[DetailViewItem(TabName = "KPI Details", IsDiffSave = true)]
        //[DBCollection(ForeignKey = "employeerefno", ForeignKeyValue = "employeerefno", ModelNo = "10706")]
        //public List<KPIListDetails_Managers> KPIListDetails_Managers { get; set; }

        [Display(Name = "IsForManager")]
        [DatabaseField(DefaultValue = "1")]
        public bool IsForManager { get; set; }

        //[Display(Name = "Output")]
        //[DatabaseField]
        //[ListViewColumn]
        //[DetailViewItem]
        //public decimal KPIOutput { get; set; }
    }
}