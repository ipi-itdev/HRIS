using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;
using System.ServiceModel.Configuration;
using Newtonsoft.Json.Bson;

namespace WCORE.Models
{
    //[MenuDescription(Name = "Department Globe")]
    //[DatabaseTable(Name = "PIS_Employee_U")]
    [DatabaseTable(Name = "View_SupervisorGlobe", PKeyName = "GlobeSupervisorRefNo")]
    public class GlobeSupervisor : BaseObject
    {
        [DatabaseField(IsRequired = true)]
        [ListViewColumn]
        [DetailViewItem(IsTextArea = true)]
        public string Description { get; set; }
    }
}