using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.Attributes
{
    internal abstract class MetaAttributeBase : Attribute
    {
        public abstract string Name { get; set; }
    }
}
