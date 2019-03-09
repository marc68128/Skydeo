using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skydeo.Domain.Entities
{
    public struct Video
    {
        public Video(string path)
        {
            Path = path;
        }

        public string Path { get; }
    }
}
