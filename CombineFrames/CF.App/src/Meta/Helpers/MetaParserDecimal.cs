using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Meta.Helpers
{
    internal static partial class MetaParser
    {

        private static decimal GetDecimal(Type type, string propertyName)
        {
            var name = GetPropertyMetaName(type, propertyName);
            var line = _lines.FirstOrDefault(_ => _.Contains(name));

            var value = GetValueInLine(line);

            if (decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
            {
                return result;
            }

            throw new Exception($"Error parse float for {propertyName}");
        }
    }
}
