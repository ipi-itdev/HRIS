using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WCORE.Utility
{
    public class Header {

        public Header() { }
        public Header(String PropertyName) {
            this.PropertyName = PropertyName;
            this.Caption = PropertyName;
            this.ColumnWidth = 150;
            this.Alignment = Align.left;
        }

        public Header( String Caption, String PropertyName ) {
            this.Caption = Caption;
            this.PropertyName = PropertyName;
        }

        public int SeqNo { get; set; }
        public bool IsVisible { get; set; }
        public string RefColumn { get; set; }
        public string RefmName { get; set; }
        public string RefField { get; set; }
        public string RefAlias { get; set; }
        public string RefTblAlias { get; set; }
        public string Caption { get; set; }
        public int ColumnWidth { get; set; }
        public string DatabaseField { get; set; }
        public string PropertyName { get; set; }
        public Align Alignment { get; set; }
        public string PropertyType { get; set; }
        public bool isDisabled { get; set; }
        public enum Align {
            left, right, center
        }

    }
}
