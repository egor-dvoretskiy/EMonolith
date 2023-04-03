using System;
using System.IO;
using YamlDotNet.Serialization;

namespace EMonolithLib.Serializers.Yaml
{
    public class YamlSerializer
    {
        private readonly IDeserializer _deserializer;
        private readonly ISerializer _serializer;

        public YamlSerializer()
        {
            _deserializer = new DeserializerBuilder().Build();
            _serializer = new SerializerBuilder().Build();
        }

        public T LoadFromFile<T>(string path)
            where T : new()
        {
            string content = string.Empty;

            try
            {
                using (StreamReader reader = new StreamReader(path, System.Text.Encoding.Default))
                {
                    content = reader.ReadToEnd();
                }

                T output = new T();
                output = _deserializer.Deserialize<T>(content);

                return output;
            }
            catch (Exception) { }

            return default(T);
        }

        public T LoadFromFile<T>(string path, T defaultValue)
            where T : new()
        {
            if (!File.Exists(path))
            {
                SaveToFile(defaultValue, path);

                return defaultValue;
            }

            T loadResult = LoadFromFile<T>(path);

            return loadResult;
        }

        public bool SaveToFile<T>(T box, string path)
            where T : new()
        {
            try
            {
                string content = _serializer.Serialize(box);
                using (StreamWriter writer = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    writer.WriteLine(content);
                }

                return true;
            }
            catch (Exception) { }

            return false;
        }
    }
}
