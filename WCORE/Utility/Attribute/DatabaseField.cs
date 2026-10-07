using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCORE.Utility
{

    [AttributeUsage( System.AttributeTargets.Property )]
    public class DatabaseFieldAttribute : Attribute
    {
        public string Name = null;
        public Type RefModel = null;
        public string RefField = null;
        public string RefTableAlias = null;
        public string RefAlias = null;
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
        public DatabaseFieldAttribute() { }
        public DatabaseFieldAttribute( String Name ) {
            this.Name = Name;
        }
    }
}