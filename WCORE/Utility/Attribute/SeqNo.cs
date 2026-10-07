using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCORE.Utility
{

    [System.AttributeUsage( System.AttributeTargets.Property )]
    public class SeqNoAttribute : Attribute
    {
        public int Index = 0;
        public SeqNoAttribute() { }
        public SeqNoAttribute( int Index ) {
            this.Index = Index;
        }
        

    }
}