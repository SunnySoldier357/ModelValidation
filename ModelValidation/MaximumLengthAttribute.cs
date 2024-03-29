﻿namespace ModelValidation
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

        /// <summary>
        /// The maximum length of the property.
        /// </summary>
        public int MaximumLength { get; set; }

        //* Constructors

        /// <param name="maximumLength">
        /// The maximum length of the property.
        /// </param>
        public MaximumLengthAttribute(int maximumLength) =>
            MaximumLength = maximumLength;

        //* Overridden Methods
        public override bool Validate<TClass, TValue>(TClass instance, TValue value,
            string nameofProperty, out string errorMessage)
        {
            errorMessage = null;

            if (value == null)
                return true;

            string strValue = value.ToString();

            bool valid = strValue.Length <= MaximumLength;

            if (ErrorMessage != null)
                errorMessage = ErrorMessage;
            else
                errorMessage = valid ? null : $"{nameofProperty} too long";

            return valid;
        }
    }
}