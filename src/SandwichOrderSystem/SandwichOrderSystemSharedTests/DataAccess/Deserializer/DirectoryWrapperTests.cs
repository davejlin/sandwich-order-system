using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SandwichOrderSystemShared.Services;
using System.IO;
using static SandwichOrderSystemShared.Constants;

namespace SandwichOrderSystemShared.DataAccess.Deserializer.Tests
{
    [TestClass()]
    public class DirectoryWrapperTests
    {
        Mock<IErrorHandler> mockErrorHandler;
        IDirectoryWrapper directoryWrapper;

        [TestInitialize()]
        public void Setup()
        {
            setupMocks();
            directoryWrapper = new DirectoryWrapper( mockErrorHandler.Object);
        }

        [TestMethod()]
        public void GetCurrentDirectoryTest()
        {
            var expected = new DirectoryInfo(Directory.GetCurrentDirectory());
            var actual = directoryWrapper.GetCurrentDirectory();
            Assert.AreEqual(expected.FullName, actual.FullName);
        }

        [TestMethod()]
        public void GetFilesTest_ReturnsEmptyEnumerableIfInvalidPath()
        {
            var badPath = "";
            var files = directoryWrapper.GetFiles(badPath);

            var i = 0;
            foreach (var file in files)
            {
                Assert.Fail("should be empty");
            }

            Assert.AreEqual(0, i, "should have no items");
            mockErrorHandler.Verify(er => er.HandleError(It.IsAny<string>()), Times.Once, "should call error handler");
        }

        [TestMethod()]
        public void ReadFileTest_ReturnsEmptyStringIfInvalidFileName()
        {
            var badFileName = "";
            var contents = directoryWrapper.ReadFile(badFileName);

            Assert.AreEqual(EMPTY_STRING, contents);
            mockErrorHandler.Verify(er => er.HandleError(It.IsAny<string>()), Times.Once, "should call error handler");
        }

        private void setupMocks()
        {
            mockErrorHandler = new Mock<IErrorHandler>();
        }
    }
}