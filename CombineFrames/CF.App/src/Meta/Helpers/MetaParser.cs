using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Meta.Attributes;
using Meta.Models;

namespace Meta.Helpers
{
    internal static partial class MetaParser
    {
        private static IEnumerable<string> _lines;

        public static MetaData ParseMetaData(string filePath)
        {
            using var sr = new StreamReader(filePath, Encoding.Default);
            var text = sr.ReadToEnd();
            _lines = text.Split('\n');
            
            var fileFormatVersion = GetInt(typeof(MetaData), nameof(MetaData.FileFormatVersion));
            var guid = GetGuid();
            var textureImporter = GetTextureImporter();

            return new MetaData
            {
                FileFormatVersion = fileFormatVersion,
                GuId = guid,
                TextureImporter = textureImporter,
            };
        }

        /// <summary>
        ///     Получить GUID мета файла
        /// </summary>
        private static string GetGuid()
        {
            var name = GetPropertyMetaName(typeof(MetaData), nameof(MetaData.GuId));

            var line = _lines.FirstOrDefault(_ => _.Contains(name));

            return GetValueInLine(line);
        }

    }
}
