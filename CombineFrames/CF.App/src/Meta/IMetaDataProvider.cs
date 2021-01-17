using System;
using System.Collections.Generic;
using System.Text;
using Meta.Models;

namespace Meta
{
    public interface IMetaDataProvider 
    {
        /// <summary>
        ///     Распарсить Мета файл
        /// </summary>
        MetaData Read(string filePath);
    }
}
