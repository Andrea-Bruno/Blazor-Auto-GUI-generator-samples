# Demo project of the automatic GUI generation tool for Blazor

This project contains two example classes located in the Panel folder. These classes create the corresponding menu items in the side panel, which open the corresponding panels represented by the class. Have fun modifying these classes because it is the easiest way to learn how they work!

### Attributes applicable to properties

For the most common types, field validation and formatting is automatically detected. For specific fields, it is possible to set validation by adding an attribute to the property.
The supported attributes are:
**[Email] [InternationalPhone] [ZipCode] [AlphanumericPostalCode] [Url] [StrongPassword] [LettersOnly] [NumbersOnly] [Alphanumeric] [Date] [IPv4] [IPv6] [CreditCard] [ProperName] [PositiveDecimal] [FileName] [ItalianTaxCode] [ItalianLicensePlate] [Time24HourFormat] [ISBN10] [ISBN13] [HexColorCode] [MACAddress] [USSocialSecurityNumber] [USPhoneNumber] [CurrencyFormat] [LatinLettersAndSpaces] [HTMLTag] [BinaryNumber] [HexadecimalNumber] [Slug] [Percentage] [UUID] [NonEmptyStrings] [DigitsWithThousandsSeparator] [MultilingualText] [FloatingPointNumber] [PositiveIntegersOnly] [NegativeIntegersOnly] [AlphaNumericWithSpaces] [UppercaseOnly] [LowercaseOnly] [TwoDecimalFloatingPoint] [USZipPlus4Code] [FilePath] [HTMLComment] [CreditCardExpirationDate] [CanadianPostalCode] [HTMLColor] [EuropeanDate] [Base64String] [YouTubeVideoID] [IPv4CIDRBlock] [TwitterUsername] [InstagramUsername] [LinkedInProfileURL] [UUIDWithBraces]**

Here is an example of how to assign an attribute to a property:

```csharp

    public static class FieldAttributes
    {
        /// <summary>
        /// Field validation using the [Url] attribute
        /// </summary>
        [Url]
        public static string? WebAddress { get; set; }
    }

```

In the example above the [url] attribute has been assigned to the WebAddress property, this will make this field validate as a url.

We can create a public method to validate a form created by the GUI representation of the class. Inside the method, just insert the code as in the example:

```csharp

        /// <summary>
        /// Press to validate all the form fields and execute and process the submission
        /// </summary>
        [DebuggerHidden] //Prevent debugging from breaking on invalid fields
        public static void Submit()
        {
            if (!UISupportGeneric.Util.ValidateClass(typeof(FieldAttributes), out var report))
            {
                string ValidationErrorsLeteral = string.Join(Environment.NewLine, report.Select(kvp => $"{kvp.Key}: {kvp.Value}"));
                throw new Exception(ValidationErrorsLeteral);
            }

            // I put here the code that will be executed when the validation is successful!
            ...
        }
```
If the class is not static, validation occurs by passing the value of the class instance using the keyword **this**:

```csharp

            if (!UISupportGeneric.Util.ValidateClass(this, out var report))
```

It is also possible to create custom attributes by setting a regular expression:

```csharp

    public class CustomFields
    {
        /// <summary>
        /// Validates that the age is an integer between 18 and 75.
        /// </summary>
        [Regex(@"^(1[89]|[2-6][0-9]|7[0-5])$")]
        public string? Age { get; set; }

        /// <summary>
        /// Validates that the email is in a standard email format.
        /// </summary>
        [Regex(@"^[\w.-]+@[\w.-]+\.[a-zA-Z]{2,}$")]
        public string? Email { get; set; }
    }
```
In this case the validation will be based on the regular expression assigned as an attribute of the property.

In most cases setting validation is not necessary, this is also thanks to the use of special words used in the property name or in its comment, however it is possible to intervene to create fields with custom validation both through a regular expression contained in the property attributes and through particular attributes.

### Range setting

The range allows to limit the value of the property within a certain range of values: Setting a range will then be reflected in the UI preventing the insertion of data outside a pre-established range.

Example of range definition for numeric properties:

```csharp
    public class Range
    {
        /// <summary>
        /// Set the selling price
        /// </summary>
        [Range(1.0, 100.0, 0.5)]
        public double Price { get; set; } = 50.5;

        /// <summary>
        /// Set up purchase of Bitcoin at the set price of one USD
        /// </summary>
        public int LimitOrder { get; set; } = 100000;
        internal int LimitOrder_Min = 50000;
        internal int LimitOrder_Max = 1500000;
        internal int LimitOrder_Step = 10000;
    }
```

As you can see from the example, there are two ways to set a range, the first by assigning an attribute to the property that defines its min, max, and step values ​​(**[Range(1.0, 100.0, 0.5)]**), and the second by using variables with the same name as the property with the addition of the suffixes **_Min, _Max, and _Step**. The second way is useful in all those cases where you need to change the range values ​​on the fly from the program, because since these are variables, they can be modified during the execution of the program.


As you can see this tool automatically creates the GUI, without writing additional code to the back-end functions, all in the simplest and most natural way possible!

### ReadOnly attribute

The [ReadOnly(true)] attribute forces properties with the public setter to be read-only as well.

```csharp
    public class ReadonlyAttribute
    {
        /// <summary>
        /// Array of strings with public setter
        /// </summary>
        public string[] StringsArray { get; set; } = ["one", "two", "three"];

        /// <summary>
        /// Array of strings with public setter and ReadOnly attribute
        /// </summary>
        [ReadOnly(true)]
        public string[] StringArrayReadonly { get; set; } = ["one", "two", "three"];
    }
```

In this example we see two arrays formally identical with the only difference that one has applied the read only attribute. The array without the ReadOnly attribute, having the public setter will be editable by the user in the GUI.
Normally, to make an element uneditable, it would be enough to set the setter as private, but if this is not possible, you can use the RaedOnly attribute.
