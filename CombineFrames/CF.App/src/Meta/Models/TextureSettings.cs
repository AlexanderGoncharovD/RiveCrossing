using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Meta.Attributes;
using Meta.Helpers;

namespace Meta.Models
{
    [MetaClass("textureSettings")]
    public class TextureSettings : ModelBase
    {
        [MetaProperty("serializedVersion")]
        public int SerializedVersion { get; set; }

        [MetaProperty("filterMode")]
        public int FilterMode { get; set; }

        [MetaProperty("aniso")]
        public int Aniso { get; set; }

        [MetaProperty("mipBias")]
        public int MipBias { get; set; }

        [MetaProperty("wrapU")]
        public int WrapU { get; set; }

        [MetaProperty("wrapV")]
        public int WrapV { get; set; }

        [MetaProperty("wrapW")]
        public int WrapW { get; set; }
        public override string ToString()
        {
            return $"{MetaDataAttributeHelper.GetTypeMetaName(typeof(TextureSettings))}:\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName((typeof(TextureSettings)), nameof(SerializedVersion))}: {SerializedVersion}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName((typeof(TextureSettings)), nameof(FilterMode))}: {FilterMode}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName((typeof(TextureSettings)), nameof(Aniso))}: {Aniso}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName((typeof(TextureSettings)), nameof(MipBias))}: {MipBias}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName((typeof(TextureSettings)), nameof(WrapU))}: {WrapU}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName((typeof(TextureSettings)), nameof(WrapV))}: {WrapV}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName((typeof(TextureSettings)), nameof(WrapW))}: {WrapW}";
        }
    }
}
