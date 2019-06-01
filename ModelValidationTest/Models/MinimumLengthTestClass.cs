using ModelValidation;

namespace ModelValidationTest.Models
{
    public class MinimumLengthTestClass : ValidatableObject
    {
        //* Public Properties
        [MinimumLength(10)]
        public string Value { get; set; }

        //* Constructors
        public MinimumLengthTestClass(string value) =>
            Value = value;
    }
}