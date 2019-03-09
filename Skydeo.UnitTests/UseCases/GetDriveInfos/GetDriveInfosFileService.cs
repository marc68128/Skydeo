using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using Skydeo.Application.Configuration;
using Skydeo.Application.Model;
using Skydeo.Domain.Entities;
using Skydeo.Infrastructure;
using Skydeo.Infrastructure.Contracts;

namespace Skydeo.UnitTests.UseCases.GetDriveInfos
{
    public class GetDriveInfosFileService : IFileService
    {
        private readonly IFileService _infrastructureImpl;
        private readonly ISerializationService _serializationService;

        public GetDriveInfosFileService()
        {
            _infrastructureImpl = new Infrastructure.FileService();
            _serializationService =new SerializationService();
        }

        public List<string> GetFilesRecursive(string directory)
        {
            var files = new List<string>
                {
                    Path.Combine(directory, GetDriveInfosConstants.PathFile1),
                    Path.Combine(directory, GetDriveInfosConstants.PathFile2),
                    Path.Combine(directory, GetDriveInfosConstants.PathVideoFile1),
                    Path.Combine(directory, GetDriveInfosConstants.PathVideoFile2),
                };

            if (directory == GetDriveInfosConstants.InitializedDrivePath)
                files.Add(Path.Combine(directory, Constants.DriveConfigurationFileName));

            return files;
        }

        public string GetFileName(string path)
        {
            return _infrastructureImpl.GetFileName(path);
        }

        public string ReadAllText(string configurationFilePath)
        {
            if (GetFileName(configurationFilePath) == Constants.DriveConfigurationFileName)
            {
                var skydiver1 = new Skydiver(GetDriveInfosConstants.Skydiver1FirstName, GetDriveInfosConstants.Skydiver1LastName);
                var alreadyTreatedVideos = new List<string>()
                {
                    Path.Combine(GetDriveInfosConstants.PathVideoFile1),
                };

                return _serializationService.Serialize(new CameraConfiguration(skydiver1, alreadyTreatedVideos));
            }

            throw new NotImplementedException();
        }

        public string GetExtension(string path)
        {
            return _infrastructureImpl.GetExtension(path);
        }
    }
}