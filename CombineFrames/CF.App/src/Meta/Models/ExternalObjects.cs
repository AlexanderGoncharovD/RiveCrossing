using System;
using System.Collections.Generic;
using System.Text;
using Meta.Attributes;
using Meta.Helpers;

namespace Meta.Models
{
    [MetaClass("externalObjects")]
    public class ExternalObjects : ModelBase
    {

        public override string ToString()
        {
            return $"{MetaDataAttributeHelper.GetTypeMetaName(typeof(ExternalObjects))}: {{}}";
        }
    }
}
