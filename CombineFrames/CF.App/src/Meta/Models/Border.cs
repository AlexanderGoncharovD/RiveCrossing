using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Meta.Attributes;
using Meta.Helpers;

namespace Meta.Models
{
    public struct Border
    {
        [MetaProperty("x")]
        public decimal X{ get; set; }

        [MetaProperty("y")]
        public decimal Y{ get; set; }

        [MetaProperty("z")]
        public decimal Z{ get; set; }

        [MetaProperty("w")]
        public decimal W{ get; set; }

        public override string ToString()
        {
            return $"{{{MetaDataAttributeHelper.GetPropertyMetaName((typeof(Border)), nameof(X))}: {X.ToString("0.0000", CultureInfo.InvariantCulture)}, " +
                   $"{MetaDataAttributeHelper.GetPropertyMetaName((typeof(Border)), nameof(Y))}: {Y.ToString("0.0000", CultureInfo.InvariantCulture)}, " +
                   $"{MetaDataAttributeHelper.GetPropertyMetaName((typeof(Border)), nameof(Z))}: {Z.ToString("0.0000", CultureInfo.InvariantCulture)}, " +
                   $"{MetaDataAttributeHelper.GetPropertyMetaName((typeof(Border)), nameof(W))}: {W.ToString("0.0000", CultureInfo.InvariantCulture)}}}";
        }
    }
}
