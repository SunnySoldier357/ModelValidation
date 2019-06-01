namespace ModelValidation
{
    /// <summary>
    /// This attribute requires that the property has a length less
    /// than the value specified. The property has to be a string,
    /// otherwise the property's ToString() method will be used as
    /// a comparison.
    /// </summary>
    public class MaximumLengthAttribute : ValidatablePropertyAttribute
    {
        //* Public Properties
        public int MaximumLength { get; set; }

        //* Constructors
        public MaximumLengthAttribute(int maximumLength) =>
            MaximumLength = maximumLength;

        //* Overriden Methods
        public override bool Validate<T>(T value, string nameofProperty,
            out string errorMessage)
        {
            string strValue = value.ToString();

            bool valid = strValue.Length <= MaximumLength;

            errorMessage = valid ? "" : $"{nameofProperty} too long";

            return valid;
        }
    }
}