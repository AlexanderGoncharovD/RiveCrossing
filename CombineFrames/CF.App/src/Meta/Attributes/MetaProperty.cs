using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class MetaProperty : MetaAttributeBase
    {
        public override string Name { get; set; }

        public MetaProperty(string name)
        {
            Name = name;
        }
    }
}
