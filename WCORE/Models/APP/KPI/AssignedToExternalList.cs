using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WCORE.Utility;

namespace WCORE.Models
{
    [DatabaseTable(Name = "fGetKPIListsClient_v2(@User)", ViewName = "fGetKPIListsClient_v2(@User)", PKeyName = "ID2")]
    public class AssignedToExternalList : BaseObject
    {
        [DatabaseField(IsRequired = true)]
        [ListViewColumn]
        [DetailViewItem(IsTextArea = true)]
        public string Position { get; set; } // anything you put in the name here would be okay hahaaha

    }
}