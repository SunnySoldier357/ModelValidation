using System;

namespace ModelValidation
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public abstract class ValidatablePropertyAttribute : Attribute
    {
        //* Public Properties

        /// <summary>
        /// A custom error message to be used instead of the default
        /// error message.
        /// </summary>
        public string ErrorMessage { get; set; }

        //* Abstract Methods
        public abstract bool Validate<TClass, TValue>(TClass instance, TValue value,
            string nameofProperty, out string errorMessage) where TClass : ValidatableObject;
    }
}