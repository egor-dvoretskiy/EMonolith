﻿using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace EMonolithLib.Serializers.Csv
{
    public static class CsvSerializer
    {
        private static readonly CsvConfiguration csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ",",
            PrepareHeaderForMatch = args => args.Header.ToLower()
        };

        public static CsvConfiguration CsvConfiguration
        {
            get => csvConfiguration;
        }

        public static IEnumerable<T> LoadFromFile<T>(string path) where T : new()
        {
            try
            {
                List<T> result;

                using (var streamReader = File.OpenText(path))
                {
                    using (var csvReader = new CsvReader(streamReader, CsvConfiguration))
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
