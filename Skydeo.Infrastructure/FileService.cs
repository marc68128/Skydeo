using System.Collections.Generic;
using System.IO;
using System.Linq;
using Skydeo.Infrastructure.Contracts;

namespace Skydeo.Infrastructure
{
    public class FileService : IFileService
    {
        public List<string> GetFilesRecursive(string directory)
        {
            var files = Directory.GetFiles(directory).ToList();
            var directories = Directory.GetDirectories(directory);

            foreach (var innerDirectory in directories)
                files.AddRange(GetFilesRecursive(innerDirectory));

            return files; 
        }

        public string GetFileName(string path)
        {
            return Path.GetFileName(path);
        }

        public string ReadAllText(string configurationFilePath)
        {
            return File.ReadAllText(configurationFilePath);
        }

        public string GetExtension(string path)
        {
            return Path.GetExtension(path);
        }
    }
}