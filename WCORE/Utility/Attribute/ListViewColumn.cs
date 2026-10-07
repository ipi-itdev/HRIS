using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCORE.Utility
{

    [System.AttributeUsage( System.AttributeTargets.Property )]
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
        public ListViewColumnAttribute( string Name ) {
            this.Name = Name;
        }
    }
}