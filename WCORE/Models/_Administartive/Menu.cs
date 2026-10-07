using WCORE.Utility;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WCORE.Models
{
    [MenuDescription(Name="Menu")]
    [DatabaseTable(Name = "SYS_WebMenu_F", PKeyName = "MenuRefNo",ViewName = "dbo.vMenuList")]
    public class Menu : BaseObject
    {
        [Display(Name = "System")]
        [DataLookUp]
        [DatabaseField(IsRequired = true, Name = "SystemRefNo", RefModel = typeof(System), RefField = "Description", RefAlias = "SYS", RefTableAlias = "SY")]
        [DetailViewItem]    
        public int SystemRefNo { get; set; }

        [Display(Name ="Menu RefNo")]
        [DatabaseField(IsRequired = true,IsUnique =true)]
        [DetailViewItem]
        [ListViewColumn]
        public int MenuRefNo { get; set; }

        [Display(Name="Model")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem]
        public string Code { get; set; }

        [DatabaseField(IsRequired = true)]
        [DetailViewItem]
        [ListViewColumn]
        public string Description { get; set; }

        [Display(Name = "Sub Description")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(IsTextArea =true)]
        public string SubDescription { get; set; }

        [Display(Name = "Form Type")]
        [DataLookUp]
        [DatabaseField(IsRequired = true,Name = "FormTypeRefNo", RefModel = typeof(FormType), RefField = "Description", RefAlias = "FT", RefTableAlias = "FType")]
        [DetailViewItem]
        public int FormType { get; set; }
        
        [Display(Name = "Sequence No")]
        [DatabaseField]
        [DetailViewItem]
        public int SeqNo { get; set; }

        [Display(Name ="Parent Menu")]
        [DataLookUp]
        [DatabaseField(Name = "MenuRefNo", RefModel = typeof(Menu), RefField = "Description", RefAlias = "MEN", RefTableAlias = "M")]
        [DetailViewItem(TabName="Properties")]
        public int MenuParentRefNo { get; set; }

        [Display(Name = "Icon")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(Column = 2, TabName = "Properties")]
        public string ImageFile { get; set; }

        [Display(Name = "Initial Controller")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(Column = 2, TabName = "Properties")]
        [ListViewColumn]
        public string ControllerName { get; set; }

        [Display(Name = "Initial Action")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(Column = 2, TabName = "Properties")]
        [ListViewColumn]
        public string ActionName { get; set; }

        [Display(Name = "List DataSource")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(Column = 2, TabName = "Properties")]
        [ListViewColumn]
        public string ListDataSource { get; set; }

        [Display(Name = "Menu Title")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(Column = 2,TabName="Properties")]
        public string MenuTitle { get; set; }

        [Display(Name = "Detail Action")]
        [DatabaseField]
        [DetailViewItem(Column = 2, TabName = "Properties")]
        public string DetailActionName { get; set; }

        [Display(Name = "Detail Controller")]
        [DatabaseField]
        [DetailViewItem(Column = 2, TabName = "Properties")]
        public string DetailControllerName { get; set; }

        [Display(Name = "View Page")]
        [DatabaseField]
        [DetailViewItem(Column = 2, TabName = "Properties")]
        public string ViewPage { get; set; }
        
        [DetailViewItem(TabName = "Button")]
        [DBCollection(ForeignKey = "MenuRefNo", ForeignKeyValue = "MenuRefNo", ModelNo = "1015")]
        public List<MenuButton> MenuButton { get; set; } 

        [DetailViewItem(TabName = "Columns")]
        [DBCollection(ForeignKey = "MenuRefNo", ForeignKeyValue = "MenuRefNo", ModelNo = "1010")]
        public List<MenuColumns> MenuColumns { get; set; }
    }
} 