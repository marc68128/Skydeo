using System.Collections.Generic;
using Skydeo.Domain.Entities;

namespace Skydeo.Application.UseCases.GetDriveInfos
{
    public class GetDriveInfosOutput
    {
        public GetDriveInfosOutput(bool isInitialized)
        {
            IsInitialized = isInitialized;
        }

        public GetDriveInfosOutput(bool isInitialized, Skydiver skydiver, IEnumerable<string> newVideos)
        {
            IsInitialized = isInitialized;
            Skydiver = skydiver;
            NewVideoPaths = newVideos;
        }

        public bool IsInitialized { get; }
        public Skydiver Skydiver { get; }
        public IEnumerable<string> NewVideoPaths { get; }
    }
}