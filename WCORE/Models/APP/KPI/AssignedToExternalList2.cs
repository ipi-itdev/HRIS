using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WCORE.Utility;

namespace WCORE.Models
{
    [DatabaseTable(Name = "fGetKPIListsClient_v2_2(@User)", ViewName = "fGetKPIListsClient_v2_2(@User)", PKeyName = "ID3")]
    public class AssignedToExternalList2 : BaseObject
    {
        [DatabaseField(IsRequired = true)]
        [ListViewColumn]
        [DetailViewItem(IsTextArea = true)]
        public string Description { get; set; } // anything you put in the name here would be okay hahaaha

    }
}