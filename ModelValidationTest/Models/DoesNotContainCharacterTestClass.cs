using ModelValidation;

namespace ModelValidationTest.Models
{
    public class DoesNotContainCharacterTestClass : ValidatableObject
    {
        //* Public Properties
        [DoesNotContainCharacter('@')]
        public string Value { get; set; }

        //* Constructors
        public DoesNotContainCharacterTestClass(string value) =>
            Value = value;
    }
}