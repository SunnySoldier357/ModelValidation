using Microsoft.VisualStudio.TestTools.UnitTesting;

using ModelValidationTest.Models;

namespace ModelValidationTest
{
    [TestClass]
    public class MaximumLengthAttributeTest
    {
        [TestMethod]
        public void NullValueTest()
        {
            var test = new MaximumLengthTestClass(null);

            Assert.IsTrue(test.Validate());
        }

        [TestMethod]
        public void ValidLengthTest()
        {
            var test = new MaximumLengthTestClass("123456");

            Assert.IsTrue(test.Validate());
        }

        [TestMethod]
        public void InvalidLengthTest()
        {
            var test = new MaximumLengthTestClass("123456789 123456789");

            Assert.IsFalse(test.Validate());
        }
    }
}