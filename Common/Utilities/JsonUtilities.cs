using System.IO;
using Newtonsoft.Json;

namespace SteviesModRedux.Common.Utilities
{
    public static class JsonUtilities
    {
        /// <summary>
        ///     Deserializes a Json file from a stream instead of opening a file according to a given path.
        /// </summary>
        public static T DeserializeJsonFromStream<T>(Stream stream) where T : notnull
        {
            using StreamReader reader = new(stream);
            using JsonTextReader textReader = new(reader);
            return new JsonSerializer().Deserialize<T>(textReader);
        }
    }
}