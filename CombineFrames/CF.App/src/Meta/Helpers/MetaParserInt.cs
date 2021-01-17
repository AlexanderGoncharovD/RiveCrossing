using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meta.Helpers
{
    internal static partial class MetaParser
    {

        private static int GetInt(Type type, string propertyName)
        {
            var name = GetPropertyMetaName(type, propertyName);
            var line = _lines.FirstOrDefault(_ => _.Contains(name));

            var value = GetValueInLine(line);

            if (int.TryParse(value, out var result))
            {
                return result;
            }

            throw new Exception($"Error parse int for {propertyName}");
        }
    }
}
