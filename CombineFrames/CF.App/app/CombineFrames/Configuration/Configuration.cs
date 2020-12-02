using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Text;
using System.Text.Json;
using CombineFrames.Models;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace CombineFrames.Configuration
{
    public class Configuration
    {
        #region Fields

        private static readonly string _configPath = Path.Combine(WorkDirectory, "config.json");
        private static bool _loading;

        #endregion
        #region Properties

        public static string WorkDirectory => Directory.GetCurrentDirectory();

        public static string TempDirectoryPath => Path.Combine(WorkDirectory, "temp");

        public static Configuration Config { get; set; }

        #region Serialization

        public string SourceDirectory { get; set; }

        public GenerationSettings GenerationSettings { get; set; }

        #endregion

        #endregion

        public static void Save()
        {
            if (_loading)
                return;

            try
            {
                using var fs = new FileStream(_configPath, FileMode.OpenOrCreate);
                System.Text.Json.JsonSerializer.SerializeAsync<Configuration>(fs, Config ?? new Configuration());
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static void Load()
        {
            _loading = true;

            if (!File.Exists(_configPath))
            {
                Config = new Configuration();
                return;
            }

            using var fs = new FileStream(_configPath, FileMode.OpenOrCreate);
            Config = System.Text.Json.JsonSerializer.DeserializeAsync<Configuration>(fs).Result;

            _loading = false;
        }
    }
}
