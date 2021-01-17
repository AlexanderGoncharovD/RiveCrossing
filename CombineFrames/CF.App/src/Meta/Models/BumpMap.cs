using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Meta.Attributes;
using Meta.Helpers;

namespace Meta.Models
{
    [MetaClass("bumpmap")]
    public class BumpMap : ModelBase
    {
        [MetaProperty("convertToNormalMap")]
        public int ConvertToNormalMap { get; set; }

        [MetaProperty("externalNormalMap")]
        public int ExternalNormalMap { get; set; }

        [MetaProperty("heightScale")]
        public decimal HeightScale { get; set; }

        [MetaProperty("normalMapFilter")]
        public int NormalMapFilter { get; set; }
        public override string ToString()
        {
            return $"{MetaDataAttributeHelper.GetTypeMetaName(typeof(BumpMap))}:\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName((typeof(BumpMap)), nameof(ConvertToNormalMap))}: {ConvertToNormalMap}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName((typeof(BumpMap)), nameof(ExternalNormalMap))}: {ExternalNormalMap}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName((typeof(BumpMap)), nameof(HeightScale))}: {HeightScale.ToString("0.00", CultureInfo.InvariantCulture)}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName((typeof(BumpMap)), nameof(NormalMapFilter))}: {NormalMapFilter}";
        }
    }
}
