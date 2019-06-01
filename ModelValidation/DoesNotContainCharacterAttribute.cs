namespace ModelValidation
{
    /// <summary>
    /// <para>
    /// This attribute requires that the property does not contain a
    /// certain character. The property has to be a string,
    /// otherwise the property's ToString() method will be used as
    /// a comparison.
    /// </para>
    /// <para>
    /// This can be useful for ensuring that an Email Property has
    /// no spaces (' ') for example.
    /// </para>
    /// </summary>
    public class DoesNotContainCharacterAttribute : ValidatablePropertyAttribute
    {
        //* Public Properties
        public char Character { get; set; }

        //* Constructors
        public DoesNotContainCharacterAttribute(char character) =>
            Character = character;

        //* Overridden Methods
        public override bool Validate<TClass, TValue>(TClass instance, TValue value,
            string nameofProperty, out string errorMessage)
        {
            errorMessage = null;

            if (value == null)
                return true;

            string strValue = value.ToString();

            bool valid = !strValue.Contains(Character.ToString());

            errorMessage = valid ? null : $"{nameofProperty} is invalid as it does" +
                $" contain a '{Character}'";

            return valid;
        }
    }
}