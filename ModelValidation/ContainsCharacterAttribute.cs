namespace ModelValidation
{
    /// <summary>
    /// <para>
    /// This attribute requires that the property contains a
    /// certain character. The property has to be a string,
    /// otherwise the property's ToString() method will be used as
    /// a comparison.
    /// </para>
    /// <para>
    /// This can be useful for checking if an Email Property contains
    /// the '@' symbol for example.
    /// </para>
    /// </summary>
    public class ContainsCharacterAttribute : ValidatablePropertyAttribute
    {
        //* Public Properties
        public char Character { get; set; }

        //* Constructors
        public ContainsCharacterAttribute(char character) =>
            Character = character;

        //* Overridden Methods
        public override bool Validate<T>(T value, string nameofProperty,
            out string errorMessage)
        {
            errorMessage = null;

            if (value == null)
                return true;

            string strValue = value.ToString();

            bool valid = strValue.Contains(Character.ToString());

            errorMessage = valid ? null : $"{nameofProperty} is invalid as it does not" +
                $" contain a '{Character}'";

            return valid;
        }
    }
}