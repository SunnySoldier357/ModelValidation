using ModelValidation;

namespace ModelValidationTest.Models
{
    public class ErrorMessageTestClass : ValidatableObject
    {
        //* Constants
        public const string ERROR_MESSAGE = "This is a test message";

        //* Public Properties
        [MaximumLength(2, ErrorMessage = ERROR_MESSAGE)]
        public string Value { get; set; }

        //* Constructors
        public ErrorMessageTestClass(string value) =>
            Value = value;
    }
}