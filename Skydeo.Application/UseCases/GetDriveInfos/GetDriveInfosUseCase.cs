using System;
using System.Collections.Generic;
using System.Linq;
using Skydeo.Application.Configuration;
using Skydeo.Application.Model;
using Skydeo.Infrastructure.Contracts;

namespace Skydeo.Application.UseCases.GetDriveInfos
{
    public sealed class GetDriveInfosUseCase : IGetDriveInfosUseCase
    {
        #region Private fields

        private readonly IFileService _fileService;
        private readonly ISerializationService _serializationService;

        #endregion

        #region Constructors

        public GetDriveInfosUseCase(IFileService fileService, ISerializationService serializationService)
        {
            _fileService = fileService;
            _serializationService = serializationService;
        }

        #endregion

        #region IGetDriveInfoUseCase

        public GetDriveInfosOutput Execute(GetDriveInfosInputs inputs)
        {
            var files = GetAllFiles(inputs.DrivePath);
            var cameraConfiguration = GetCameraConfiguration(files);

            if (cameraConfiguration == null)
                return new GetDriveInfosOutput(false);
            
            var videos = GetVideoPaths(files);
            var newVideos = ExcludeAlreadyTreatedVideos(videos, cameraConfiguration.AlreadyTreatedVideos); 

            return new GetDriveInfosOutput(true, cameraConfiguration.Skydiver, newVideos);
        }

        #endregion
        
        #region Private methods

        private List<string> GetAllFiles(string rootDirectoryPath)
        {
            return _fileService.GetFilesRecursive(rootDirectoryPath);
        }

        private CameraConfiguration GetCameraConfiguration(IEnumerable<string> files)
        {
            var configurationFilePath = files.FirstOrDefault(f => _fileService.GetFileName(f) == Constants.DriveConfigurationFileName);

            if (configurationFilePath == null)
                return null;

            return _serializationService.Deserialize<CameraConfiguration>(_fileService.ReadAllText(configurationFilePath));
        }

        private IEnumerable<string> GetVideoPaths(IEnumerable<string> filePaths)
        {
            return filePaths.Where(f => GetVideosExtensions().Contains(_fileService.GetExtension(f).ToLower()));
        }

        private IEnumerable<string> GetVideosExtensions()
        {
            return Enum.GetNames(typeof(VideoExtensions)).Select(e => $".{e.ToLower()}"); 
        }

        private IEnumerable<string> ExcludeAlreadyTreatedVideos(IEnumerable<string> allVideos, IEnumerable<string> alreadyTreatedVideos)
        {
            return allVideos.Except(alreadyTreatedVideos).ToList();
        }

        #endregion
    }
} 