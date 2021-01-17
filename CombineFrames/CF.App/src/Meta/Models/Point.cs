using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using Meta.Attributes;
using Meta.Helpers;

namespace Meta.Models
{
    public struct Point
    {
        [MetaProperty("x")]
        public decimal X { get; set; }

        [MetaProperty("y")]
        public decimal Y { get; set; }
        
        public override string ToString()
        {
            return $"{{{MetaDataAttributeHelper.GetPropertyMetaName((typeof(Point)), nameof(X))}: {X.ToString("0.0000", CultureInfo.InvariantCulture)}, " +
                   $"{MetaDataAttributeHelper.GetPropertyMetaName((typeof(Point)), nameof(Y))}: {Y.ToString("0.0000", CultureInfo.InvariantCulture)}}}";
        }
    }
}
