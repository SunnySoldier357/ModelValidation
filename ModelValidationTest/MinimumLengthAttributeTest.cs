using Microsoft.VisualStudio.TestTools.UnitTesting;

using ModelValidationTest.Models;

namespace ModelValidationTest
{
    [TestClass]
    public class MinimumLengthAttributeTest
    {
        //* Test Methods

        [TestMethod]
        public void NullValueTest()
        {
            var test = new MinimumLengthTestClass(null);

            Assert.IsTrue(test.Validate());
            Assert.IsTrue(test.Errors.Count == 0);
        }

        [TestMethod]
        public void ValidLengthTest()
        {
            var test = new MinimumLengthTestClass("123456789 123456789");

            Assert.IsTrue(test.Validate());
            Assert.IsTrue(test.Errors.Count == 0);
        }

        [TestMethod]
        public void InvalidLengthTest()
        {
            var test = new MinimumLengthTestClass("123456");

            Assert.IsFalse(test.Validate());
            Assert.IsTrue(test.Errors.Count == 1);
            Assert.IsTrue(test.Errors[0] == $"{nameof(test.Value)} too short");
        }
    }
}