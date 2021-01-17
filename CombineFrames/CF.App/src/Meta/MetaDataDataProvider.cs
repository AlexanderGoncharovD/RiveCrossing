using System;
using System.Collections.Generic;
using System.Text;
using Meta.Helpers;
using Meta.Models;

namespace Meta
{
    public class MetaDataDataProvider : IMetaDataProvider
    {
        /// <summary>
        ///     Инициализировать провайдер
        /// </summary>
        public static MetaDataDataProvider Initialize()
        {
            var provider = new MetaDataDataProvider();
            return provider;
        }

        public MetaData Read(string filePath)
        {
            var result = MetaParser.ParseMetaData(filePath);

            return result;
        }
    }
}
