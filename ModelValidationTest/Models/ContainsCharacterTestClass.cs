using ModelValidation;

namespace ModelValidationTest.Models
{
    public class ContainsCharacterTestClass : ValidatableObject
    {
        //* Public Properties
        [ContainsCharacter('@')]
        public string Value { get; set; }

        //* Constructors
        public ContainsCharacterTestClass(string value) =>
            Value = value;
    }
}