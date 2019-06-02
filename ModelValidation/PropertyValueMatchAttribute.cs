using System.Reflection;

namespace ModelValidation
{
    public class PropertyValueMatchAttribute : ValidatablePropertyAttribute
    {
        //* Public Properties

        /// <summary>
        /// The name of the other property to compare the selected property
        /// with.
        /// </summary>
        public string OtherPropertyName { get; set; }

        //* Constructors

        /// <param name="otherPropertyName">
        /// The name of the other property to compare the selected property
        /// with.
        /// </param>
        public PropertyValueMatchAttribute(string otherPropertyName) =>
            OtherPropertyName = otherPropertyName;

        //* Overridden Methods
        public override bool Validate<TClass, TValue>(TClass instance, TValue value,
            string nameofProperty, out string errorMessage)
        {
            PropertyInfo otherProperty = instance.GetType().GetProperty(OtherPropertyName);
            object otherValue = otherProperty.GetValue(instance);

            bool valid = value?.Equals(otherValue) ?? otherValue == null;

            if (ErrorMessage != null)
                errorMessage = ErrorMessage;
            else
                errorMessage = valid ? "" : $"{nameofProperty} does not match" +
                    $" {OtherPropertyName}";

            return valid;
        }
    }
}