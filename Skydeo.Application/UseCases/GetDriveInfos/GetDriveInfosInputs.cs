namespace Skydeo.Application.UseCases.GetDriveInfos
{
    public class GetDriveInfosInputs
    {
        public GetDriveInfosInputs(string drivePath)
        {
            DrivePath = drivePath;
        }

        public string DrivePath { get; }
    }
}