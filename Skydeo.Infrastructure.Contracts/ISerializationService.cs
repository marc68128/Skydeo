namespace Skydeo.Infrastructure.Contracts
{
    public interface ISerializationService
    {
        string Serialize(object obj);
        T Deserialize<T>(string serializedString);
    }
}