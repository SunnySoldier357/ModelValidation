using Microsoft.VisualStudio.TestTools.UnitTesting;

using ModelValidationTest.Models;

namespace ModelValidationTest
{
    [TestClass]
    public class MultipleAttributesTest
    {
        //* Test Methods

        [TestMethod]
        public void NullValueTest() => testValidValidation(null);

        [TestMethod]
        public void BothInvalidTest()
        {
            var test = new MultipleAttributesTestClass("");

            Assert.IsFalse(test.Validate());
            Assert.IsTrue(test.Errors.Count == 2);
            Assert.IsTrue(test.Errors.Contains($"{nameof(test.Value)} is invalid as it" +
                " does not contain a '@'"));
            Assert.IsTrue(test.Errors.Contains($"{nameof(test.Value)} too short"));
        }

        [TestMethod]
        public void SingleValidTest()
        {
            var test = new MultipleAttributesTestClass("@");

            Assert.IsFalse(test.Validate());
            Assert.IsTrue(test.Errors.Count == 1);
            Assert.IsTrue(test.Errors.Contains($"{nameof(test.Value)} too short"));
        }

        [TestMethod]
        public void BothValidTest() => testValidValidation("sss@sss");

        //* Private Properties
        private void testValidValidation(string value)
        {
            var test = new MultipleAttributesTestClass(value);

            Assert.IsTrue(test.Validate());
            Assert.IsTrue(test.Errors.Count == 0);
        }
    }
}