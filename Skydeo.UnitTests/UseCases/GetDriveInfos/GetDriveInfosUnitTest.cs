using System.Linq;
using NUnit.Framework;
using Skydeo.Application.UseCases.GetDriveInfos;
using Skydeo.Infrastructure;

namespace Skydeo.UnitTests.UseCases.GetDriveInfos
{
    [TestFixture]
    public class GetDriveInfosUnitTest
    {
        private readonly IGetDriveInfosUseCase _getDriveInfosUseCase;

        public GetDriveInfosUnitTest()
        {
            _getDriveInfosUseCase = new GetDriveInfosUseCase(new GetDriveInfosFileService(), new SerializationService());
        }


        [Test]
        public void NotInitializedDriveTest()
        {
            var testPath = GetDriveInfosConstants.NotInitializedDrivePath;
            var output = _getDriveInfosUseCase.Execute(new GetDriveInfosInputs(testPath)); 
            Assert.IsFalse(output.IsInitialized);
        }

        [Test]
        public void InitializedDriveTest()
        {
            var testPath = GetDriveInfosConstants.InitializedDrivePath;
            var output = _getDriveInfosUseCase.Execute(new GetDriveInfosInputs(testPath));
            Assert.IsTrue(output.IsInitialized);
        }

        [Test]
        public void NotInitializedDriveTest_ShouldReturnNullSkydiverInfo()
        {
            var testPath = GetDriveInfosConstants.NotInitializedDrivePath;
            var output = _getDriveInfosUseCase.Execute(new GetDriveInfosInputs(testPath));
            Assert.IsNull(output.Skydiver);
        }

        [Test]
        public void InitializedDriveTest_ShouldReturnSkydiverInfo()
        {
            var testPath = GetDriveInfosConstants.InitializedDrivePath;
            var output = _getDriveInfosUseCase.Execute(new GetDriveInfosInputs(testPath));
            Assert.IsNotNull(output.Skydiver);
        }

        [Test]
        public void InitializedDriveTest_ShouldReturnNewVideoFile()
        {
            var testPath = GetDriveInfosConstants.InitializedDrivePath;
            var output = _getDriveInfosUseCase.Execute(new GetDriveInfosInputs(testPath));
            Assert.IsNotNull(output.NewVideoPaths);
            Assert.AreEqual(1, output.NewVideoPaths.Count());
        }


    }
}
