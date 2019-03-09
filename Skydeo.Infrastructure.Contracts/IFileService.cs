using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skydeo.Infrastructure.Contracts
{
    public interface IFileService
    {
        List<string> GetFilesRecursive(string directory);
        string GetFileName(string path);
        string ReadAllText(string configurationFilePath);
        string GetExtension(string path);
    }
}
