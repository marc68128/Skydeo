using Newtonsoft.Json;
using Skydeo.Infrastructure.Contracts;

namespace Skydeo.Infrastructure
{
    public class SerializationService : ISerializationService
    {
        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public T Deserialize<T>(string serializedString)
        {
            return JsonConvert.DeserializeObject<T>(serializedString);
        }
    }
}