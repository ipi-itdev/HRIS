using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCORE.Utility
{

    [System.AttributeUsage( System.AttributeTargets.Property )]
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
        public string ViewId = null;
        public string TabName = DEFAULT_TAB;
        public string Box = DEFAULT_BOX;
        public string mName = null;
        public int TabIndex = 0;
        public int Column = 0;
        public string strFormat = null;
        public int mLength = 100;
        public DetailViewItemAttribute() { }
        public DetailViewItemAttribute( String Name ) {
            this.Name = Name;
        }
        

    }
}