using System;

namespace WCORE.Utility
{
    [System.AttributeUsage( System.AttributeTargets.Class |
                       System.AttributeTargets.Struct )]
    public class CaptionAttribute : Attribute
    {
        public string Name = null;
        public CaptionAttribute() { }
        public CaptionAttribute( String Name ) {
            this.Name = Name;
        }
    }

    [AttributeUsage(System.AttributeTargets.Property)]
    public class DatabaseFieldAttribute : Attribute
    {
        public string Name = null; // Used to determine the foreign key name from the parent table
        public Type RefModel = null; // Used if the field is lookup
        public string RefField = null; // Used if the field is lookup
        public string RefTableAlias = null; // Used if the field is lookup
        public string RefAlias = null; // Used if the field is lookup
        public bool AllowInsert = true;
        public bool AllowUpdate = true;
        public bool IsRequired = false;
        public bool IsUnique = false;
        public bool IsTable = false;
        public bool NotInTable = false;
        public int Column = 0;
        public string TbName = null;
        public string ControlID = null;
        public string DefaultValue = null;
        public bool IsProperCase = false;
        public bool IsEncrypt = false;
        public DatabaseFieldAttribute() { }
        public DatabaseFieldAttribute(String Name)
        {
            this.Name = Name;
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Class |
                       System.AttributeTargets.Struct)]
    public class DatabaseTableAttribute : Attribute
    {
        public string Name = null;
        public string ViewName = null;
        public string PKeyName = null;
        public string SeqBy = "Description";
        public string DataLookupSource = null;

        public DatabaseTableAttribute() { }
        public DatabaseTableAttribute(String Name)
        {
            this.Name = Name;
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Class |
                  System.AttributeTargets.Struct)]
    public class MenuDescriptionAttribute : Attribute
    {
        public string Name = null;
        public string SubName = null;
        public bool HasDefault = false;
        public bool WOOthers = false;
        public MenuDescriptionAttribute() { }
        public MenuDescriptionAttribute(String Name)
        {
            this.Name = Name;
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class DataLookUpAttribute : Attribute
    {
        public string ViewId = null;
        public string ColumnValue = "ID";
        public string DisplayColumnValue = "Description";
        public bool WithAdd = false;
        public bool IsJson = false;
        public bool IsEnum = false; // add for get list - 08-08-2024
        public DataLookUpAttribute() { }
        public DataLookUpAttribute(String ViewId)
        {
            this.ViewId = ViewId;
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Class |
                       System.AttributeTargets.Struct)]
    public class DataSourceAttribute : Attribute
    {
        public string Name = null;
        public DataSourceAttribute() { }
        public DataSourceAttribute(String Name)
        {
            this.Name = Name;
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class DBCollection : Attribute
    {
        //public string mguid = null; // add variable or string mguid to test noel may 21
        public string ModelNo = null;
        public string ForeignKey = null;
        public string ForeignKeyValue = null;
        public bool IsAggregated = true;
        public bool IsForm = false;
    }

    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class DetailViewItemAttribute : Attribute
    {
        public const string DEFAULT_TAB = "Details";
        public const string DEFAULT_BOX = "";
        public string Name = null;
        public bool IsEnabled = true;
        public bool IsTextArea = false;
        public bool IsTextEditor = false;
        public bool IsDateRange = false;
        public bool IsEmail = false;
        public bool IsDiffSave = false;
        public bool IsVisible = true;
        public string ViewId = null;
        public string TabName = DEFAULT_TAB;
        public string Box = DEFAULT_BOX;
        public string mName = null;
        public int TabIndex = 0;
        public int Column = 0;
        public string strFormat = null;
        public int mLength = 100;
        public DetailViewItemAttribute() { }
        public DetailViewItemAttribute(String Name)
        {
            this.Name = Name;
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Class |
                    System.AttributeTargets.Struct)]
    public class DisplayPropertyAttribute : Attribute
    {
        public DisplayPropertyAttribute(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
    }

    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class ListViewColumnAttribute : Attribute
    {
        public string Name = null;
        public bool IsVisible = true;
        public bool IsEditable = false;
        public int Width = 300;
        public int SeqNo = 0;
        public string Align = "L";
        public int ControlType = 0;
        public ListViewColumnAttribute() { }
        public ListViewColumnAttribute(string Name)
        {
            this.Name = Name;
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Class |
                      System.AttributeTargets.Struct)]
    public class ListViewFormatAttribute : Attribute
    {
        public string ViewId = null;
        public bool IsEditable = true;
        public string[] Format;
        public ListViewFormatAttribute()
        {
        }
        public ListViewFormatAttribute(String ViewId)
        {
            this.ViewId = ViewId;
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class SeqNoAttribute : Attribute
    {
        public int Index = 0;
        public SeqNoAttribute() { }
        public SeqNoAttribute(int Index)
        {
            this.Index = Index;
        }


    }
}