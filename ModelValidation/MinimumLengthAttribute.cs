namespace ModelValidation
{
    /// <summary>
    /// This attribute requires that the property has a length more
    /// than the value specified. The property has to be a string,
    /// otherwise the property's ToString() method will be used as
    /// a comparison.
    /// </summary>
    public class MinimumLengthAttribute : ValidatablePropertyAttribute
    {
        //* Public Properties
        public int MinimumLength { get; set; }

        //* Constructors
        public MinimumLengthAttribute(int minimumLength) =>
            MinimumLength = minimumLength;

        //* Overridden Methods
        public override bool Validate<T>(T value, string nameofProperty,
            out string errorMessage)
        {
            string strValue = value.ToString();

            bool valid = strValue.Length >= MinimumLength;

            errorMessage = valid ? "" : $"{nameofProperty} too short";

            return valid;
        }
    }
}