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
            Assert.IsTrue(test.Errors.Count == 0);
        }

        [TestMethod]
        public void ValidLengthTest()
        {
            var test = new MaximumLengthTestClass("123456");

            Assert.IsTrue(test.Validate());
            Assert.IsTrue(test.Errors.Count == 0);
        }

        [TestMethod]
        public void InvalidLengthTest()
        {
            var test = new MaximumLengthTestClass("123456789 123456789");

            Assert.IsFalse(test.Validate());
            Assert.IsTrue(test.Errors.Count == 1);
            Assert.IsTrue(test.Errors[0] == $"{nameof(test.Name)} too long");
        }
    }
}