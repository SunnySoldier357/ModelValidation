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

        /// <summary>
        /// The minimum length of the property.
        /// </summary>
        public int MinimumLength { get; set; }

        //* Constructors

        /// <param name="minimumLength">
        /// The minimum length of the property.
        /// </param>
        public MinimumLengthAttribute(int minimumLength) =>
            MinimumLength = minimumLength;

        //* Overridden Methods
        public override bool Validate<TClass, TValue>(TClass instance, TValue value,
            string nameofProperty, out string errorMessage)
        {
            errorMessage = null;

            if (value == null)
                return true;

            string strValue = value.ToString();

            bool valid = strValue.Length >= MinimumLength;

            if (ErrorMessage != null)
                errorMessage = ErrorMessage;
            else
                errorMessage = valid ? null : $"{nameofProperty} too short";

            return valid;
        }
    }
}