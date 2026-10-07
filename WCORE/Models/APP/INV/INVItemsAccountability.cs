using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name="Items")]
    [DatabaseTable(Name = "ItemsAccountability",PKeyName ="ID")]
    public class INVItemsAccountability : BaseObject
    {
        [Display(Name = "Item")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem]
        [ListViewColumn]
        public string Description { get; set; }
    }
}