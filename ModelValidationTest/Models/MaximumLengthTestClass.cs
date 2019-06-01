using ModelValidation;

namespace ModelValidationTest.Models
{
    public class MaximumLengthTestClass : ValidatableObject
    {
        //* Public Properties
        [MaximumLength(10)]
        public string Name { get; set; }

        //* Constructors
        public MaximumLengthTestClass(string name) =>
            Name = name;
    }
}