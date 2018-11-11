using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Locust.Extensions;

namespace Locust.UnitTest
{
    [TestClass]
    public class IOHelperTest
    {
        [TestMethod]
        public void TestLocalDirIsEmpty()
        {
            var result = IOHelper.IsDirectoryEmpty("E:\\1\\2");

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestLocalDirIsNotEmpty()
        {
            var result = !IOHelper.IsDirectoryEmpty("c:\\windows");

            Assert.IsTrue(result);
        }
    }
}
