using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SandwichOrderSystemShared.DataAccess.Deserializer.Tests
{
    [TestClass()]
    public class DataParserTests
    {
        IDataParser dataParser;

        [TestInitialize()]
        public void Setup()
        {
            dataParser = new DataParser();
        }

        [TestMethod()]
        public void ParseDataTest()
        {
            var prop1 = "prop1";
            var prop2 = "prop2";
            var prop3 = "prop3";
            var prop4 = "prop4";
            var prop5 = "prop5";
            var prop6 = "prop6";
            var prop7 = "prop7";
            var prop8 = "prop8";
            var prop9 = "prop9";
            var prop10 = "prop10";

            var expectedProperties = new string[]
            {
                prop1, prop2, prop3, prop4, prop5, prop6, prop7, prop8, prop9, prop10
            };

            var inputString = string.Format(
                "{0},{1}\n {2},{3} \r\n{4}  ,{5}  \n \r\n  \n        {6} \r\n , ,, {7}\n,{8},,{9},,,",
                prop1, prop2, prop3, prop4, prop5, prop6, prop7, prop8, prop9, prop10);

            var actualProperties = dataParser.ParseData(inputString);

            var i = 0;
            foreach (var properties in actualProperties)
            {
                foreach(var prop in properties)
                {
                    Assert.AreEqual(expectedProperties[i++], prop, "should have parsed property");
                }
            }
        }
    }
}