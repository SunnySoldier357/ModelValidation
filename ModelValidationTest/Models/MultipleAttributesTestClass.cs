using ModelValidation;

namespace ModelValidationTest.Models
{
    public class MultipleAttributesTestClass : ValidatableObject
    {
        //* Public Properties
        [ContainsCharacter('@')]
        [MinimumLength(2)]
        public string Value { get; set; }

        //* Constructors
        public MultipleAttributesTestClass(string value) => 
            Value = value;
    }
}