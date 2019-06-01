using System;

namespace ModelValidation
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class ValidatablePropertyAttribute : Attribute
    {
        //* Abstract Methods
        public abstract bool Validate<T>(T value, string nameofProperty,
            out string errorMessage);
    }
}