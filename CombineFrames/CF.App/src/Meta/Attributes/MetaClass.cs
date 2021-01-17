using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class MetaClass : MetaAttributeBase
    {
        public override string Name { get; set; }

        public MetaClass(string name)
        {
            Name = name;
        }
    }
}
