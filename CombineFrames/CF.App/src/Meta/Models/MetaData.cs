using System;
using System.Collections.Generic;
using System.Text;
using Meta.Attributes;
using Meta.Helpers;

namespace Meta.Models
{
    public class MetaData
    {
        /// <summary>
        ///     Формат Мета файла
        /// </summary>
        [MetaProperty("fileFormatVersion")]
        public int FileFormatVersion { get; set; }

        /// <summary>
        ///     Уникальный идентификатор файла
        /// </summary>
        [MetaProperty("guid")]
        public string GuId { get; set; }

        /// <summary>
        ///     Параметры импорта текстуры
        /// </summary>
        public TextureImporter TextureImporter { get; set; }

        public override string ToString()
        {
            return $"{MetaDataAttributeHelper.GetPropertyMetaName(typeof(MetaData), nameof(FileFormatVersion))}: {FileFormatVersion}\n" +
                   $"{MetaDataAttributeHelper.GetPropertyMetaName(typeof(MetaData), nameof(GuId))}: {GuId}\n" +
                   $"{TextureImporter.Print(0)}" +
                   $"";
        }
    }
}
