using EMonolithLib.Serializers.Csv;
using System.Collections.Immutable;

namespace NUnitEMonolithTests
{
    public class CsvData
    {
        public string Assignment { get; set; }

        public string Organization { get; set; }
    }

    public class CsvSerializerTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var data = CsvSerializer.LoadFromFile<CsvData>("D:\\_workspace_C#\\Misc\\Mac_Addresses.csv");
           
            Assert.Pass();
        }
    }
}