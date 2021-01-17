using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Meta.Models;

namespace Meta.Helpers
{
    internal static partial class MetaParser
    {

        private static TextureImporter GetTextureImporter()
        {
            var name = GetClassMetaName(typeof(TextureImporter));

            var line = _lines.FirstOrDefault(_ => _.Contains(name));

            if (string.IsNullOrEmpty(line))
                throw new Exception("Parse failed. TextureImporter not found");

            return new TextureImporter
            {
                FileIdToRecycleName = GetFileIdToRecycleName(),
                ExternalObjects = GetExternalObjects(),
                SerializedVersion = GetInt(typeof(TextureImporter), nameof(TextureImporter.SerializedVersion)),
                MipMaps = GetMipMap(),
                BumpMap = GetBumpMap(),
                IsReadable = GetInt(typeof(TextureImporter), nameof(TextureImporter.IsReadable)),
                StreamingMipMaps = GetInt(typeof(TextureImporter), nameof(TextureImporter.StreamingMipMaps)),
                StreamingMipMapsPriority = GetInt(typeof(TextureImporter), nameof(TextureImporter.StreamingMipMapsPriority)),
                GrayScaleToAlpha = GetInt(typeof(TextureImporter), nameof(TextureImporter.GrayScaleToAlpha)),
                GenerateCubeMap = GetInt(typeof(TextureImporter), nameof(TextureImporter.GenerateCubeMap)),
                CubeMapConvolution = GetInt(typeof(TextureImporter), nameof(TextureImporter.CubeMapConvolution)),
                SeamlessCubeMap = GetInt(typeof(TextureImporter), nameof(TextureImporter.SeamlessCubeMap)),
                TextureFormat = GetInt(typeof(TextureImporter), nameof(TextureImporter.TextureFormat)),
                MaxTextureSize = GetInt(typeof(TextureImporter), nameof(TextureImporter.MaxTextureSize)),
                TextureSettings = GetTextureSettings(),
                NPOTScale = GetInt(typeof(TextureImporter), nameof(TextureImporter.NPOTScale)),
                LightMap = GetInt(typeof(TextureImporter), nameof(TextureImporter.LightMap)),
                CompressionQuality = GetInt(typeof(TextureImporter), nameof(TextureImporter.CompressionQuality)),
                SpriteMode = GetInt(typeof(TextureImporter), nameof(TextureImporter.SpriteMode)),
                SpriteExtrude = GetInt(typeof(TextureImporter), nameof(TextureImporter.SpriteExtrude)),
                SpriteMeshType = GetInt(typeof(TextureImporter), nameof(TextureImporter.SpriteMeshType)),
                Alignment = GetInt(typeof(TextureImporter), nameof(TextureImporter.Alignment)),
                SpritePivot = GetStructPoint(typeof(TextureImporter), nameof(TextureImporter.SpritePivot)),
                SpritePixelsToUnits = GetDecimal(typeof(TextureImporter), nameof(TextureImporter.SpritePixelsToUnits)),
                SpriteBorder = GetStructBorder(typeof(TextureImporter), nameof(TextureImporter.SpriteBorder)),
                SpriteGenerateFallbackPhysicsShape = GetInt(typeof(TextureImporter), nameof(TextureImporter.SpriteGenerateFallbackPhysicsShape)),
                AlphaUsage = GetInt(typeof(TextureImporter), nameof(TextureImporter.AlphaUsage)),
                AlphaIsTransparency = GetInt(typeof(TextureImporter), nameof(TextureImporter.AlphaIsTransparency)),
                SpriteTessellationDetail = GetInt(typeof(TextureImporter), nameof(TextureImporter.SpriteTessellationDetail)),
                TextureType = GetInt(typeof(TextureImporter), nameof(TextureImporter.TextureType)),
                TextureShape = GetInt(typeof(TextureImporter), nameof(TextureImporter.TextureShape)),
                SingleChannelComponent = GetInt(typeof(TextureImporter), nameof(TextureImporter.SingleChannelComponent)),
                MaxTextureSizeSet = GetInt(typeof(TextureImporter), nameof(TextureImporter.MaxTextureSizeSet)),
                CompressionQualitySet = GetInt(typeof(TextureImporter), nameof(TextureImporter.CompressionQualitySet)),
                TextureFormatSet = GetInt(typeof(TextureImporter), nameof(TextureImporter.TextureFormatSet)),
            };
        }
        private static ExternalObjects GetExternalObjects()
        {
            var name = GetClassMetaName(typeof(ExternalObjects));
            var line = _lines.FirstOrDefault(_ => _.Contains(name));

            if (!string.IsNullOrEmpty(line))
            {
                return new ExternalObjects();
            }

            throw new Exception($"Not found {nameof(TextureImporter.ExternalObjects)}");
        }

        private static MipMaps GetMipMap()
        {
            var name = GetClassMetaName(typeof(MipMaps));
            var line = _lines.FirstOrDefault(_ => _.Contains(name));

            if (!string.IsNullOrEmpty(line))
            {
                return new MipMaps
                {
                    MipMapMode = GetInt(typeof(MipMaps), nameof(MipMaps.MipMapMode)),
                    EnableMipMap = GetInt(typeof(MipMaps), nameof(MipMaps.EnableMipMap)),
                    SRGBTexture = GetInt(typeof(MipMaps), nameof(MipMaps.SRGBTexture)),
                    LinearTexture = GetInt(typeof(MipMaps), nameof(MipMaps.LinearTexture)),
                    FadeOut = GetInt(typeof(MipMaps), nameof(MipMaps.FadeOut)),
                    BorderMipMap = GetInt(typeof(MipMaps), nameof(MipMaps.BorderMipMap)),
                    MipMapsPreserveCoverage = GetInt(typeof(MipMaps), nameof(MipMaps.MipMapsPreserveCoverage)),
                    AlphaTestReferenceValue = GetDecimal(typeof(MipMaps), nameof(MipMaps.AlphaTestReferenceValue)),
                    MipMapFadeDistanceStart = GetInt(typeof(MipMaps), nameof(MipMaps.MipMapFadeDistanceStart)),
                    MipMapFadeDistanceEnd = GetInt(typeof(MipMaps), nameof(MipMaps.MipMapFadeDistanceEnd)),
                };
            }

            throw new Exception($"Not found {nameof(TextureImporter.MipMaps)}");
        }

        private static BumpMap GetBumpMap()
        {
            var name = GetClassMetaName(typeof(BumpMap));
            var line = _lines.FirstOrDefault(_ => _.Contains(name));

            if (!string.IsNullOrEmpty(line))
            {
                return new BumpMap
                {
                    ConvertToNormalMap = GetInt(typeof(BumpMap), nameof(BumpMap.ConvertToNormalMap)),
                    ExternalNormalMap = GetInt(typeof(BumpMap), nameof(BumpMap.ExternalNormalMap)),
                    HeightScale = GetDecimal(typeof(BumpMap), nameof(BumpMap.HeightScale)),
                    NormalMapFilter = GetInt(typeof(BumpMap), nameof(BumpMap.NormalMapFilter)),
                };
            }

            throw new Exception($"Not found {nameof(TextureImporter.MipMaps)}");
        }

        private static TextureSettings GetTextureSettings()
        {
            var name = GetClassMetaName(typeof(TextureSettings));
            var line = _lines.FirstOrDefault(_ => _.Contains(name));

            if (!string.IsNullOrEmpty(line))
            {
                return new TextureSettings
                {
                    SerializedVersion = GetInt(typeof(TextureSettings), nameof(TextureSettings.SerializedVersion)),
                    FilterMode = GetInt(typeof(TextureSettings), nameof(TextureSettings.FilterMode)),
                    Aniso = GetInt(typeof(TextureSettings), nameof(TextureSettings.Aniso)),
                    WrapU = GetInt(typeof(TextureSettings), nameof(TextureSettings.WrapU)),
                    WrapV = GetInt(typeof(TextureSettings), nameof(TextureSettings.WrapV)),
                    WrapW = GetInt(typeof(TextureSettings), nameof(TextureSettings.WrapW)),
                };
            }

            throw new Exception($"Not found {nameof(TextureImporter.MipMaps)}");
        }
    }
}
