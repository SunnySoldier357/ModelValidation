# Model Validation

A [NuGet Package](https://www.nuget.org/packages/ModelValidation/) to aid with
validating Models through the use of Attributes.

## Use

### The Model

Any model or class that wants to be validatable should inherit from
`ValidatableObject`. This adds the `Validate()` method to the class, which
automatically validates the class according to the attributes assigned to its
properties.

### Attributes

The base attribute is `ValidatablePropertyAttribute` which defines its own
`Validate()` method to validate a property based on a single rule. This project
defines several attributes that inherit from `ValidatablePropertyAttribute`
which can be used.

- `MaximumLength` Attribute

    Ensures that the property does not exceed the specified maximum length

- `MinimumLength` Attribute

    Ensures that the property exceeds the specified minimum length

- `ContainsCharacter` Attribute

    Ensures that the property contains the specified character. (Useful for
    checking that an email has an '@' symbol)

- `DoesNotContainCharacter` Attribute

    Ensures that the property does not contain the specified container. (Useful
    for checking that a property has no spaces or `' '`)

- `PropertyValueMatch` Attribute

    Ensures that the property's value matches with the value of the other
    specified property (Useful for checking that passwords match - `Password` &
    `ConfirmPassword` properties have to match)

### Custom Attributes

Any class can extend from the base `ValidatablePropertyAttribute` and define
custom validation attributes.

## Example Model

``` csharp
using ModelValidation;

public class TestModel : ValidatableObject
{
    [MinimumLength(2)]
    [MaximumLength(64)]
    public string UserName { get; set; }

    [ContainsCharacter('@')]
    [DoesNotContainCharacter(' ')]
    [MinimumLength(5)]
    [MaximumLength(254)]
    public string Email { get; set; }

    [MinimumLength(8)]
    [MaximumLength(64)]
    public string Password { get; set; }

    [PropertyValueMatch(nameof(Password))]
    public string ConfirmPassword { get; set; }
}
```

Calling `TestModel.Validate()` validates the model and stores any error messages
into the `Errors` property, which is a `List<string>`.
