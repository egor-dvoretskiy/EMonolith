using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace EMonolithLib.Serializers.Csv
{
    public static class CsvSerializer
    {
        public static IEnumerable<T> LoadFromFile<T>(string path) where T : new()
        {
            try
            {
                List<T> result;

                using (var streamReader = File.OpenText(path))
                {
                    using (var csvReader = new CsvReader(streamReader, CultureInfo.CurrentCulture))
                    {
                        var list = csvReader.GetRecords<T>();
                        result = new List<T>();

                        foreach (var item in list)
                        {
                            result.Add(item);
                        }
                    }
                }

                return result;
            }
            catch (Exception) { }

            return default(List<T>);
        }

        public static bool SaveToFile<T>(T box, string path) where T : new()
        {
            throw new NotImplementedException();
        }
    }
}
