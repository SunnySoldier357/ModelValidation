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

        /// <summary>
        /// The character that the property must contain.
        /// </summary>
        public char Character { get; set; }

        //* Constructors

        /// <param name="character">
        /// The character that the property must contain.
        /// </param>
        public ContainsCharacterAttribute(char character) =>
            Character = character;

        //* Overridden Methods
        public override bool Validate<TClass, TValue>(TClass instance, TValue value,
            string nameofProperty, out string errorMessage)
        {
            errorMessage = null;

            if (value == null)
                return true;

            string strValue = value.ToString();

            bool valid = strValue.Contains(Character.ToString());

            if (ErrorMessage != null)
                errorMessage = ErrorMessage;
            else
                errorMessage = valid ? null : $"{nameofProperty} is invalid as it does not" +
                    $" contain a '{Character}'";

            return valid;
        }
    }
}