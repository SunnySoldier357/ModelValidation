using Microsoft.VisualStudio.TestTools.UnitTesting;

using ModelValidationTest.Models;

namespace ModelValidationTest
{
    [TestClass]
    public class MinimumLengthAttributeTest
    {
        [TestMethod]
        public void NullValueTest()
        {
            var test = new MinimumLengthTestClass(null);

            Assert.IsTrue(test.Validate());
        }

        [TestMethod]
        public void ValidLengthTest()
        {
            var test = new MinimumLengthTestClass("123456789 123456789");

            Assert.IsTrue(test.Validate());
        }

        [TestMethod]
        public void InvalidLengthTest()
        {
            var test = new MinimumLengthTestClass("123456");

            Assert.IsFalse(test.Validate());
        }
    }
}