using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
            var entry1 = "entry1";
            var entry2 = "entry2";
            var entry3 = "entry3";
            var entry4 = "entry4";
            var entry5 = "entry5";
            var entry6 = "entry6";
            var entry7 = "entry7";
            var entry8 = "entry8";
            var entry9 = "entry9";
            var entry10 = "entry10";

            var inputValues = new string[]
            {
                entry1, entry2, entry3, entry4, entry5, entry6, entry7, entry8, entry9, entry10
            };

            var inputString = string.Format(
                "{0},{1}\n {2},{3} \r\n{4}  ,{5}  \n \r\n  \n        {6} \r\n , ,, {7}\n,{8},,{9},,,",
                entry1, entry2, entry3, entry4, entry5, entry6, entry7, entry8, entry9, entry10);

            var outputEnumerable = dataParser.ParseData(inputString);

            var i = 0;
            foreach (var properties in outputEnumerable)
            {
                foreach(var property in properties)
                {
                    Assert.AreEqual(inputValues[i++], property);
                }
            }
        }
    }
}