using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Meta.Attributes;
using Meta.Helpers;

namespace Meta.Models
{
    [MetaClass("TextureImporter")]
    public class TextureImporter : ModelBase
    {
        /// <summary>
        ///     Словарь Id и названий спрайтов
        /// </summary>
        [MetaProperty("fileIDToRecycleName")]
        public Dictionary<int, string> FileIdToRecycleName { get; set; } = new Dictionary<int, string>();

        /// <summary>
        ///     Внешние объекты
        /// </summary>
        public ExternalObjects ExternalObjects { get; set; }

        /// <summary>
        ///     Версия сериализации
        /// </summary>
        [MetaProperty("serializedVersion")]
        public int SerializedVersion { get; set; }

        public MipMaps MipMaps { get; set; }

        public BumpMap BumpMap { get; set; }
        
        [MetaProperty("isReadable")]
        public int IsReadable { get; set; }

        [MetaProperty("streamingMipmaps")]
        public int StreamingMipMaps { get; set; }

        [MetaProperty("streamingMipmapsPriority")]
        public int StreamingMipMapsPriority { get; set; }

        [MetaProperty("grayScaleToAlpha")]
        public int GrayScaleToAlpha { get; set; }

        [MetaProperty("generateCubemap")]
        public int GenerateCubeMap { get; set; }

        [MetaProperty("cubemapConvolution")]
        public int CubeMapConvolution { get; set; }

        [MetaProperty("seamlessCubemap")]
        public int SeamlessCubeMap { get; set; }

        [MetaProperty("textureFormat")]
        public int TextureFormat { get; set; }

        [MetaProperty("maxTextureSize")]
        public int MaxTextureSize { get; set; }

        public TextureSettings TextureSettings { get; set; }

        [MetaProperty("nPOTScale")]
        public int NPOTScale { get; set; }

        [MetaProperty("lightmap")]
        public int LightMap { get; set; }

        [MetaProperty("compressionQuality")]
        public int CompressionQuality { get; set; }

        [MetaProperty("spriteMode")]
        public int SpriteMode { get; set; }

        [MetaProperty("spriteExtrude")]
        public int SpriteExtrude { get; set; }

        [MetaProperty("spriteMeshType")]
        public int SpriteMeshType { get; set; }

        [MetaProperty("alignment")]
        public int Alignment { get; set; }

        [MetaProperty("spritePivot")]
        public Point SpritePivot { get; set; }

        [MetaProperty("spritePixelsToUnits")]
        public decimal SpritePixelsToUnits { get; set; }

        [MetaProperty("spriteBorder")]
        public Border SpriteBorder { get; set; }

        [MetaProperty("spriteGenerateFallbackPhysicsShape")]
        public int SpriteGenerateFallbackPhysicsShape { get; set; }

        [MetaProperty("alphaUsage")]
        public int AlphaUsage { get; set; }

        [MetaProperty("alphaIsTransparency")]
        public int AlphaIsTransparency { get; set; }

        [MetaProperty("spriteTessellationDetail")]
        public int SpriteTessellationDetail { get; set; }

        [MetaProperty("textureType")]
        public int TextureType { get; set; }

        [MetaProperty("textureShape")]
        public int TextureShape { get; set; }

        [MetaProperty("singleChannelComponent")]
        public int SingleChannelComponent { get; set; }

        [MetaProperty("maxTextureSizeSet")]
        public int MaxTextureSizeSet { get; set; }

        [MetaProperty("compressionQualitySet")]
        public int CompressionQualitySet { get; set; }

        [MetaProperty("textureFormatSet")]
        public int TextureFormatSet { get; set; }


        #region Private Methods

        private string PrintDictionary(Dictionary<int, string> dictionary)
        {
            var result =
                $"{MetaDataAttributeHelper.GetPropertyMetaName(typeof(TextureImporter), nameof(FileIdToRecycleName))}:\n" +
                $"{Tab}    {string.Join($"\n{Tab}    ", dictionary.Select(_ => $"{_.Key}: {_.Value}"))}";
            
            return result;
        }

        public override string ToString()
        {
            return $"{Tab}{MetaDataAttributeHelper.GetTypeMetaName(typeof(TextureImporter))}:\n" +
                   $"{Tab}  {PrintDictionary(FileIdToRecycleName)}\n" +
                   $"{Tab}  {ExternalObjects.Print(2)}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName(typeof(TextureImporter), nameof(SerializedVersion))}: {SerializedVersion}\n" +
                   $"{Tab}  {MipMaps.Print(2)}\n" +
                   $"{Tab}  {BumpMap.Print(2)}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName(typeof(TextureImporter), nameof(IsReadable))}: {IsReadable}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName(typeof(TextureImporter), nameof(StreamingMipMaps))}: {StreamingMipMaps}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName(typeof(TextureImporter), nameof(StreamingMipMapsPriority))}: {StreamingMipMapsPriority}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName(typeof(TextureImporter), nameof(GrayScaleToAlpha))}: {GrayScaleToAlpha}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName(typeof(TextureImporter), nameof(GenerateCubeMap))}: {GenerateCubeMap}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName(typeof(TextureImporter), nameof(CubeMapConvolution))}: {CubeMapConvolution}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName(typeof(TextureImporter), nameof(SeamlessCubeMap))}: {SeamlessCubeMap}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName(typeof(TextureImporter), nameof(TextureFormat))}: {TextureFormat}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName(typeof(TextureImporter), nameof(MaxTextureSize))}: {MaxTextureSize}\n" +
                   $"{Tab}  {TextureSettings.Print(2)}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName(typeof(TextureImporter), nameof(NPOTScale))}: {NPOTScale}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName(typeof(TextureImporter), nameof(LightMap))}: {LightMap}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName(typeof(TextureImporter), nameof(CompressionQuality))}: {CompressionQuality}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName(typeof(TextureImporter), nameof(SpriteMode))}: {SpriteMode}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName(typeof(TextureImporter), nameof(SpriteExtrude))}: {SpriteExtrude}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName(typeof(TextureImporter), nameof(SpriteMeshType))}: {SpriteMeshType}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName(typeof(TextureImporter), nameof(Alignment))}: {Alignment}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName(typeof(TextureImporter), nameof(SpritePivot))}: {SpritePivot}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName(typeof(TextureImporter), nameof(SpritePixelsToUnits))}: {SpritePixelsToUnits}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName(typeof(TextureImporter), nameof(SpriteBorder))}: {SpriteBorder}\n" +

                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName(typeof(TextureImporter), nameof(SpriteGenerateFallbackPhysicsShape))}: {SpriteGenerateFallbackPhysicsShape}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName(typeof(TextureImporter), nameof(AlphaUsage))}: {AlphaUsage}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName(typeof(TextureImporter), nameof(AlphaIsTransparency))}: {AlphaIsTransparency}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName(typeof(TextureImporter), nameof(SpriteTessellationDetail))}: {SpriteTessellationDetail}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName(typeof(TextureImporter), nameof(TextureType))}: {TextureType}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName(typeof(TextureImporter), nameof(TextureShape))}: {TextureShape}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName(typeof(TextureImporter), nameof(SingleChannelComponent))}: {SingleChannelComponent}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName(typeof(TextureImporter), nameof(MaxTextureSizeSet))}: {MaxTextureSizeSet}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName(typeof(TextureImporter), nameof(CompressionQualitySet))}: {CompressionQualitySet}\n" +
                   $"{Tab}  {MetaDataAttributeHelper.GetPropertyMetaName(typeof(TextureImporter), nameof(TextureFormatSet))}: {TextureFormatSet}\n" +
                   $"";
        }

        #endregion
    }
}
