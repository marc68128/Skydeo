using System.Collections.Generic;
using Skydeo.Domain.Entities;

namespace Skydeo.Application.Model
{
    public class CameraConfiguration
    {
        public CameraConfiguration(Skydiver skydiver, List<string> alreadyTreatedVideos)
        {
            Skydiver = skydiver;
            AlreadyTreatedVideos = alreadyTreatedVideos;
        }

        public Skydiver Skydiver { get; }
        public List<string> AlreadyTreatedVideos { get; }
    }
}