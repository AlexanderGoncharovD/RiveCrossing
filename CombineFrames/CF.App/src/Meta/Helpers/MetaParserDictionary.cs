using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Meta.Models;

namespace Meta.Helpers
{
    internal static partial class MetaParser
    {

        private static Dictionary<int, string> GetFileIdToRecycleName()
        {
            var name = GetPropertyMetaName(typeof(TextureImporter), nameof(TextureImporter.FileIdToRecycleName));

            var line = _lines.FirstOrDefault(_ => _.Contains(name));

            // Взять следущую строку, то значение словарика под индексом 0
            var indexLine = _lines.ToList().IndexOf(line) + 1;

            var dictionary = new Dictionary<int, string>();

            foreach (var dictionaryLine in _lines.Skip(indexLine))
            {
                var (key, value) = GetKeyAndValue(dictionaryLine);

                if (key == null && string.IsNullOrEmpty(value))
                {
                    return dictionary;
                }

                dictionary.Add((int)key, value);
            }

            return dictionary;

            static (int?, string) GetKeyAndValue(string line)
            {
                var index = line.IndexOf(':');
                var kStr = line.Substring(0, index);
                var v = GetValueInLine(line);

                if (int.TryParse(kStr, out var k))
                {
                    return (k, v);
                }

                return (null, null);
            }
        }
    }
}
