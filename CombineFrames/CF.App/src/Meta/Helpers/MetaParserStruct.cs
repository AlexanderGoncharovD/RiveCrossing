using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Meta.Models;

namespace Meta.Helpers
{
    internal static partial class MetaParser
    {

        private static Point GetStructPoint(Type type, string propertyName)
        {
            GetValuesStruct(type, propertyName, out var values);

            return new Point
            {
                X = GetDecimalValueStruct(typeof(Point), nameof(Point.X), values, propertyName),
                Y = GetDecimalValueStruct(typeof(Point), nameof(Point.Y), values, propertyName),
            };

        }

        private static Border GetStructBorder(Type type, string propertyName)
        {
            GetValuesStruct(type, propertyName, out var values);

            return new Border
            {
                X = GetDecimalValueStruct(typeof(Border), nameof(Border.X), values, propertyName),
                Y = GetDecimalValueStruct(typeof(Border), nameof(Border.Y), values, propertyName),
                Z = GetDecimalValueStruct(typeof(Border), nameof(Border.Z), values, propertyName),
                W = GetDecimalValueStruct(typeof(Border), nameof(Border.W), values, propertyName),
            };
        }

        private static void GetValuesStruct(Type type, string propertyName, out IEnumerable<string> values)
        {
            var name = GetPropertyMetaName(type, propertyName);
            var line = _lines.FirstOrDefault(_ => _.Contains(name))?
                .Replace("{", "")
                .Replace("}", "")
                .GetValue();

            values = line.Split(", ");
        }

        private static decimal GetDecimalValueStruct(Type structType, string name, IEnumerable<string> values, string propertyName)
        {
            var metaName = GetPropertyMetaName(structType, name);
            var str = values.FirstOrDefault(_ => _.Contains(metaName));

            if (!decimal.TryParse(str.GetValue(), NumberStyles.Any, CultureInfo.InvariantCulture, out var x))
                throw new Exception($"Error parse decimal for {propertyName}.{metaName}");

            return x;
        }
    }
}
