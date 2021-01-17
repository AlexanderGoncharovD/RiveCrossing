using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Meta.Attributes;
using Meta.Helpers;

namespace Meta.Models
{
    [MetaClass("mipmaps")]
    public class MipMaps : ModelBase
    {
        [MetaProperty("mipMapMode")]
        public int MipMapMode { get; set; }

        [MetaProperty("enableMipMap")]
        public int EnableMipMap { get; set; }

        [MetaProperty("sRGBTexture")]
        public int SRGBTexture { get; set; }

        [MetaProperty("linearTexture")]
        public int LinearTexture { get; set; }

        [MetaProperty("fadeOut")]
        public int FadeOut { get; set; }

        [MetaProperty("borderMipMap")]
        public int BorderMipMap { get; set; }

        [MetaProperty("mipMapsPreserveCoverage")]
        public int MipMapsPreserveCoverage { get; set; }

        [MetaProperty("alphaTestReferenceValue")]
        public decimal AlphaTestReferenceValue { get; set; }

        [MetaProperty("mipMapFadeDistanceStart")]
        public int MipMapFadeDistanceStart { get; set; }

        [MetaProperty("mipMapFadeDistanceEnd")]
        public int MipMapFadeDistanceEnd { get; set; }

        public override string ToString()
        {
            return $"{MetaDataAttributeHelper.GetTypeMetaName(typeof(MipMaps))}:\n" +  
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName((typeof(MipMaps)), nameof(MipMapMode))}: {MipMapMode}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName((typeof(MipMaps)), nameof(EnableMipMap))}: {EnableMipMap}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName((typeof(MipMaps)), nameof(SRGBTexture))}: {SRGBTexture}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName((typeof(MipMaps)), nameof(LinearTexture))}: {LinearTexture}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName((typeof(MipMaps)), nameof(FadeOut))}: {FadeOut}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName((typeof(MipMaps)), nameof(BorderMipMap))}: {BorderMipMap}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName((typeof(MipMaps)), nameof(MipMapsPreserveCoverage))}: {MipMapsPreserveCoverage}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName((typeof(MipMaps)), nameof(AlphaTestReferenceValue))}: {AlphaTestReferenceValue.ToString("0.00", CultureInfo.InvariantCulture)}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName((typeof(MipMaps)), nameof(MipMapFadeDistanceStart))}: {MipMapFadeDistanceStart}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName((typeof(MipMaps)), nameof(MipMapFadeDistanceEnd))}: {MipMapFadeDistanceEnd}";
        }
    }
}
