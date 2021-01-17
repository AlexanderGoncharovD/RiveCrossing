using System;

namespace Meta.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var arg in args)
            {
                var index = arg.IndexOf(':');
                var command = arg.Substring(0, index);
                switch (command)
                {
                    case "parse":
                        index++;
                        var filePath = arg.Substring(index, arg.Length - index);
                        var metaProvider = MetaDataDataProvider.Initialize();
                        var meta = metaProvider.Read(filePath);
                        Console.WriteLine(meta);
                        break;
                    default:
                        throw new Exception("Unknown command");
                }
            }
        }
    }
}
