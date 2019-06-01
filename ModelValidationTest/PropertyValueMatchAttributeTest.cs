using Microsoft.VisualStudio.TestTools.UnitTesting;

using ModelValidationTest.Models;

namespace ModelValidationTest
{
    [TestClass]
    public class PropertyValueMatchAttributeTest
    {
        //* Test Methods

        [TestMethod]
        public void ValuesNullTest() => testValidValidation(null, null);

        [TestMethod]
        public void DependentNullTest() => testInvalidValidation("test", null);

        [TestMethod]
        public void IndependentNullTest() => testInvalidValidation(null, "test");

        [TestMethod]
        public void ValuesDifferentTest() => testInvalidValidation("different", "test");

        [TestMethod]
        public void ValidTest() => testValidValidation("test", "test");

        //* Private Properties
        private void testValidValidation(string independent, string dependent)
        {
            var test = new PropertyValueMatchTestClass(independent, dependent);

            Assert.IsTrue(test.Validate());
            Assert.IsTrue(test.Errors.Count == 0);
        }

        private void testInvalidValidation(string independent, string dependent)
        {
            var test = new PropertyValueMatchTestClass(independent, dependent);

            Assert.IsFalse(test.Validate());
            Assert.IsTrue(test.Errors.Count == 1);
            Assert.IsTrue(test.Errors[0] == $"{nameof(test.Dependent)} does not match" +
                $" {nameof(test.Independent)}");
        }
    }
}