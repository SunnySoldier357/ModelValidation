using Microsoft.VisualStudio.TestTools.UnitTesting;

using ModelValidationTest.Models;

namespace ModelValidationTest
{
    [TestClass]
    public class ErrorMessageTest
    {
        [TestMethod]
        public void NullTest()
        {
            var test = new ErrorMessageTestClass(null);

            Assert.IsTrue(test.Validate());
            Assert.IsTrue(test.Errors.Count == 0);
        }

        [TestMethod]
        public void InvalidTest()
        {
            var test = new ErrorMessageTestClass("123456789");

            Assert.IsFalse(test.Validate());
            Assert.IsTrue(test.Errors.Count == 1);
            Assert.IsTrue(test.Errors[0] == ErrorMessageTestClass.ERROR_MESSAGE);
        }
    }
}