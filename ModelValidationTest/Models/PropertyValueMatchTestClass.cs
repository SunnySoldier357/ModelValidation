using ModelValidation;

namespace ModelValidationTest.Models
{
    public class PropertyValueMatchTestClass : ValidatableObject
    {
        //* Public Properties
        [PropertyValueMatch(nameof(Independent))]
        public string Dependent { get; set; }
        public string Independent { get; set; }

        //* Constructors
        public PropertyValueMatchTestClass(string independent, string dependent)
        {
            Dependent = dependent;
            Independent = independent;
        }
    }
}