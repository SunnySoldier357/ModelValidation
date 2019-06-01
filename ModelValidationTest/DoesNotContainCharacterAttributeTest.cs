using Microsoft.VisualStudio.TestTools.UnitTesting;

using ModelValidationTest.Models;

namespace ModelValidationTest
{
    [TestClass]
    public class DoesNotContainCharacterAttributeTest
    {
        [TestMethod]
        public void NullValueTest()
        {
            var test = new DoesNotContainCharacterTestClass(null);

            Assert.IsTrue(test.Validate());
            Assert.IsTrue(test.Errors.Count == 0);
        }

        [TestMethod]
        public void ValidLengthTest()
        {
            var test = new DoesNotContainCharacterTestClass("test something.com");

            Assert.IsTrue(test.Validate());
            Assert.IsTrue(test.Errors.Count == 0);
        }

        [TestMethod]
        public void InvalidLengthTest()
        {
            var test = new DoesNotContainCharacterTestClass("test@something.com");

            Assert.IsFalse(test.Validate());
            Assert.IsTrue(test.Errors.Count == 1);
            Assert.IsTrue(test.Errors[0] == $"{nameof(test.Value)} is invalid as it does" +
                " contain a '@'");
        }
    }
}