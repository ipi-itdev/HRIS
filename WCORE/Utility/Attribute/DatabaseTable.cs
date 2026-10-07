using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCORE.Utility
{
    [System.AttributeUsage( System.AttributeTargets.Class |
                       System.AttributeTargets.Struct )]
    public class DatabaseTableAttribute : Attribute
    {
        public string Name = null;
        public string ViewName = null;
        public string DataLookupSource = null;
        public string PKeyName = null;
        public bool DUV = false;
        public string SeqBy = "Description";

        public DatabaseTableAttribute() { }
        public DatabaseTableAttribute( String Name ) {
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
}