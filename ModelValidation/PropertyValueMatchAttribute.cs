using System.Reflection;

namespace ModelValidation
{
    public class PropertyValueMatchAttribute : ValidatablePropertyAttribute
    {
        //* Public Properties
        public string OtherPropertyName { get; set; }

        //* Constructors
        public PropertyValueMatchAttribute(string otherPropertyName) => 
            OtherPropertyName = otherPropertyName;

        //* Overridden Methods
        public override bool Validate<TClass, TValue>(TClass instance, TValue value,
            string nameofProperty, out string errorMessage)
        {
            PropertyInfo otherProperty = instance.GetType().GetProperty(OtherPropertyName);
            object otherValue = otherProperty.GetValue(instance);

            bool valid = value?.Equals(otherValue) ?? otherValue == null;

            errorMessage = valid ? "" : $"{nameofProperty} does not match" +
                $" {OtherPropertyName}";

            return valid;
        }
    }
}