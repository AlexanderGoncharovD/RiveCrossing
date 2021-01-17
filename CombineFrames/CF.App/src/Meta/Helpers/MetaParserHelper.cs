using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.Helpers
{
    internal static partial class MetaParser
    {

        private static string GetPropertyMetaName(Type type, string property)
        {
            var name = MetaDataAttributeHelper.GetPropertyMetaName(type, property);

            if (string.IsNullOrEmpty(name))
                throw new Exception($"Not found name field in {property}");

            return name;
        }

        private static string GetClassMetaName(Type type)
        {
            var name = MetaDataAttributeHelper.GetTypeMetaName(type);

            if (string.IsNullOrEmpty(name))
                throw new Exception($"Not found name field in {type}");

            return name;
        }

        private static string GetValueInLine(string line)
        {
            var index = line.IndexOf(':') + 1;
            var result = line.Substring(index, line.Length - index)
                .Replace("\r", string.Empty)
                .TrimStart();
            return result;
        }

        private static string GetValue(this string line)
        {
            var index = line.IndexOf(':') + 1;
            var result = line.Substring(index, line.Length - index)
                .Replace("\r", string.Empty)
                .TrimStart();
            return result;
        }
    }
}
