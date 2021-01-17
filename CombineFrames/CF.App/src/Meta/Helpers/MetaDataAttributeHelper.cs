using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Meta.Attributes;
using Meta.Models;

namespace Meta.Helpers
{
    internal static class MetaDataAttributeHelper
    {
       /// <summary>
        ///     Получить имя, отображаемое в мета файле, из атрибута
        /// </summary>
        /// <param name="propertyName">Имя свойства из класса</param>
        /// <returns>Имя для мета файла</returns>
        internal static string GetPropertyMetaName(Type type, string propertyName)
        {
            var properties = type.GetProperties();
            var info = properties.FirstOrDefault(_ => _.Name == propertyName && _.GetCustomAttributes<MetaAttributeBase>(false).Any());

            if (info == null)
                throw new Exception($"Not found attribute {typeof(MetaAttributeBase)}");

            var attributes = info.GetCustomAttributes<MetaAttributeBase>(false);
            var name = attributes.FirstOrDefault()?.Name;

            return name;
        }

       /// <summary>
       ///      Получить имя класса из атрибута
       /// </summary>
       /// <param name="type">Класс</param>
       internal static string GetTypeMetaName(Type type)
       {
           var attributes = type.GetCustomAttributes<MetaAttributeBase>(false);
           var name = attributes.FirstOrDefault()?.Name;

           if (string.IsNullOrEmpty(name))
               throw new Exception($"Not found attribute {typeof(MetaAttributeBase)}");
           
           return name;
       }
    }
}
