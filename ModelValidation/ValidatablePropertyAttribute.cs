using System;

namespace ModelValidation
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public abstract class ValidatablePropertyAttribute : Attribute
    {
        //* Abstract Methods
        public abstract bool Validate<TClass, TValue>(TClass instance, TValue value,
            string nameofProperty, out string errorMessage) where TClass : ValidatableObject;
    }
}