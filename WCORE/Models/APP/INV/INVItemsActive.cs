using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name="Items")]
    [DatabaseTable(Name = "INV_Items_U",ViewName = "dbo.fItems(@User)", PKeyName ="ID")]
    public partial class INVItemsActive : BaseObject
    {

        [DataLookUp]
        [Display(Name = "Type")]
        [DatabaseField(IsRequired = true, RefModel = typeof(ItemsType), RefField = "Description", RefTableAlias = "ITT", Name = "ID", RefAlias = "ITT")]
        [DetailViewItem]
        [ListViewColumn(Width = 100)]
         public int ItemTypeRefNo { get; set; }

        [Display(Name = "Item")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem]
        [ListViewColumn(Width = 350)]
        public string ItemName { get; set; }

        [DatabaseField]
        [DetailViewItem]
        [ListViewColumn]
        public string Description { get; set; }

        [Display(Name = "SerialNumber")]
        [DatabaseField]
        [DetailViewItem]
        public string SerialNumber { get; set; }

        [Display(Name = "Is Rented?")]
        [DatabaseField]
        [DetailViewItem]
        public bool IsRented { get; set; }

        [Display(Name = "Owned By")]
        [DataLookUp]
        [DatabaseField(RefModel = typeof(Department), RefField = "Description", RefTableAlias = "Dep", Name = "ID", RefAlias = "Dep")]
        [DetailViewItem]
        [ListViewColumn]
        public int DepOwnedBy { get; set; }

        [Display(Name = "Date Purchased")]  
        [DatabaseField]
        [DetailViewItem]
        public DateTime DatePurchased { get; set; }

        [DatabaseField]
        [DetailViewItem]
        public int SupplierRefNo { get; set; }

        [DatabaseField]
        [DetailViewItem]
        public bool IsForExternal { get; set; }

        [DatabaseField]
        [DetailViewItem]
        public string Warranty { get; set; }

        [Display(Name = "Licensed Date")]
        [DatabaseField]
        [DetailViewItem]
        public DateTime LicensedEndDate { get; set; }

        [DatabaseField]
        [DetailViewItem]
        public decimal Price { get; set; }

        [Display(Name = "Present Value")]
        [DatabaseField]
        [DetailViewItem(IsEnabled=false)]
        public decimal PresentValue { get; set; }

        [DatabaseField]
        [DetailViewItem]
        public string Remarks { get; set; }

        [Display(Name = "Item Status")]
        [DataLookUp]
        [DatabaseField(NotInTable = true,AllowInsert =false,AllowUpdate =false)]
        [ListViewColumn]
        public string ItemStatus { get; set; }

        [Display(Name = "Item Status")]
        [DataLookUp]
        [DatabaseField(RefModel = typeof(ItemStatus), RefField = "Description", RefTableAlias = "IS", Name = "ID", RefAlias = "IS",DefaultValue = "1")]
        public int ItemStatusRefNo { get; set; }

        [Display(Name = "Item Details")]
        [DetailViewItem(TabName = "INVItemDetails", IsDiffSave = true)]
        [DBCollection(ForeignKey = "ItemsRefNo", ForeignKeyValue = "ID", ModelNo = "30110")]
        public List<INVItemDetails> INVItemDetails { get; set; }

        [Display(Name = "Item History")]
        [DetailViewItem(TabName = "INVItemHistory", IsDiffSave = true)]
        [DBCollection(ForeignKey = "ItemsRefNo", ForeignKeyValue = "ID", ModelNo = "30120")]
        public List<INVItemHistory> INVItemHistory { get; set; }

        
   
    }
}