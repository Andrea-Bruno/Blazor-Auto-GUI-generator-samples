using System.Diagnostics;

namespace FieldSetting.Panels
{
    /// <summary>
    /// A class containing a collection of static properties to represent special information and configurations.
    /// Notes on this example project: The code file that is rendered in the panel, whose entry appears in the side menu, is the one in the project folder called Panels. The example demonstrates several properties with one of the special words in the description. As you can see, the display of the property on the page takes on appropriate characteristics based on the context, thanks to the presence of the special word.
    /// You can add other classes in the Panels folder to add new menu items and panels in the GUI that is the web page.
    /// As you can see this page is static, which means that the fields entered here are for general use (not related to the user's browsing session). Static classes therefore keep the values ​​set in the GUI even after a reboot, this saves a lot of time as there is no need to write save routines.
    /// In this example page we have properties marked with attributes that will determine the validation of the field while typing.
    /// The supported attributes are:
    /// [Email] [InternationalPhone] [ZipCode] [AlphanumericPostalCode] [Url] [StrongPassword] [LettersOnly] [NumbersOnly] [Alphanumeric] [Date] [IPv4] [IPv6] [CreditCard] [ProperName] [PositiveDecimal] [FileName] [ItalianTaxCode] [ItalianLicensePlate] [Time24HourFormat] [ISBN10] [ISBN13] [HexColorCode] [MACAddress] [USSocialSecurityNumber] [USPhoneNumber] [CurrencyFormat] [LatinLettersAndSpaces] [HTMLTag] [BinaryNumber] [HexadecimalNumber] [Slug] [Percentage] [UUID] [NonEmptyStrings] [DigitsWithThousandsSeparator] [MultilingualText] [FloatingPointNumber] [PositiveIntegersOnly] [NegativeIntegersOnly] [AlphaNumericWithSpaces] [UppercaseOnly] [LowercaseOnly] [TwoDecimalFloatingPoint] [USZipPlus4Code] [FilePath] [HTMLComment] [CreditCardExpirationDate] [CanadianPostalCode] [HTMLColor] [EuropeanDate] [Base64String] [YouTubeVideoID] [IPv4CIDRBlock] [TwitterUsername] [InstagramUsername] [LinkedInProfileURL] [UUIDWithBraces]
    /// </summary>
    public static class FieldAttributes
    {
        /// <summary>
        /// Field validation example
        /// </summary>
        [Email]
        public static string? Email { get; set; }

        /// <summary>
        /// Field validation example
        /// </summary>
        [InternationalPhone]
        public static string? InternationalPhoneNumber { get; set; }

        /// <summary>
        /// Field validation using the [ZipCode] attribute
        /// </summary>
        [ZipCode]
        public static string? ZipCode { get; set; }

        /// <summary>
        /// Field validation using the [AlphanumericPostalCode] attribute
        /// </summary>
        [AlphanumericPostalCode]
        public static string? AlphanumericPostalCode { get; set; }

        /// <summary>
        /// Field validation using the [Url] attribute
        /// </summary>
        [Url]
        public static string? Url { get; set; }

        /// <summary>
        /// Field validation using the [StrongPassword] attribute
        /// </summary>
        [StrongPassword]
        public static string? StrongPassword { get; set; }

        /// <summary>
        /// Field validation using the [LettersOnly] attribute
        /// </summary>
        [LettersOnly]
        public static string? LettersOnly { get; set; }

        /// <summary>
        /// Field validation using the [NumbersOnly] attribute
        /// </summary>
        [NumbersOnly]
        public static string? NumbersOnly { get; set; }

        /// <summary>
        /// Field validation using the [Alphanumeric] attribute
        /// </summary>
        [Alphanumeric]
        public static string? Alphanumeric { get; set; }

        /// <summary>
        /// Field validation using attribute
        /// </summary>
        [Date]
        public static string? Day { get; set; }

        /// <summary>
        /// Field validation using the [IPv4] attribute
        /// </summary>
        [IPv4]
        public static string? IPv4Address { get; set; }

        /// <summary>
        /// Field validation using the [IPv6] attribute
        /// </summary>
        [IPv6]
        public static string? IPv6Address { get; set; }

        /// <summary>
        /// Field validation using the [CreditCard] attribute
        /// </summary>
        [CreditCard]
        public static string? CreditCardNumber { get; set; }

        /// <summary>
        /// Field validation using the [ProperName] attribute
        /// </summary>
        [ProperName]
        public static string? ProperName { get; set; }

        /// <summary>
        /// Field validation using the [PositiveDecimal] attribute
        /// </summary>
        [PositiveDecimal]
        public static string? PositiveDecimal { get; set; }

        /// <summary>
        /// Field validation using the [FileName] attribute
        /// </summary>
        [FileName]
        public static string? FileName { get; set; }

        /// <summary>
        /// Field validation using the [ItalianTaxCode] attribute
        /// </summary>
        [ItalianTaxCode]
        public static string? ItalianTaxCode { get; set; }

        /// <summary>
        /// Field validation using the [ItalianLicensePlate] attribute
        /// </summary>
        [ItalianLicensePlate]
        public static string? ItalianLicensePlate { get; set; }

        /// <summary>
        /// Field validation using the [Time24HourFormat] attribute
        /// </summary>
        [Time24HourFormat]
        public static string? Time24HourFormat { get; set; }
        /// <summary>
        /// Field validation using the [ISBN10] attribute
        /// </summary>
        [ISBN10]
        public static string? Isbmn10 { get; set; }

        /// <summary>
        /// Field validation using the [ISBN13] attribute
        /// </summary>
        [ISBN13]
        public static string? Isbmn13 { get; set; }

        /// <summary>
        /// Field validation example
        /// </summary>
        [HexColorCode]
        public static string? HexCode { get; set; }

        /// <summary>
        /// Field validation using the [MACAddress] attribute
        /// </summary>
        [MACAddress]
        public static string? MacAddress { get; set; }

        /// <summary>
        /// Field validation using the [USSocialSecurityNumber] attribute
        /// </summary>
        [USSocialSecurityNumber]
        public static string? UsSocialSecurityNumber { get; set; }

        /// <summary>
        /// Field validation using the [USPhoneNumber] attribute
        /// </summary>
        [USPhoneNumber]
        public static string? UsPhoneNumber { get; set; }

        /// <summary>
        /// Field validation using the [CurrencyFormat] attribute
        /// </summary>
        [CurrencyFormat]
        public static string? Currency { get; set; }

        /// <summary>
        /// Field validation using the [LatinLettersAndSpaces] attribute
        /// </summary>
        [LatinLettersAndSpaces]
        public static string? LatinLettersAndSpaces { get; set; }

        /// <summary>
        /// Field validation using the [HTMLTag] attribute
        /// </summary>
        [HTMLTag]
        public static string? HtmlTag { get; set; }

        /// <summary>
        /// Field validation using the [BinaryNumber] attribute
        /// </summary>
        [BinaryNumber]
        public static string? BinaryNumber { get; set; }

        /// <summary>
        /// Field validation using the [HexadecimalNumber] attribute
        /// </summary>
        [HexadecimalNumber]
        public static string? HexadecimalNumber { get; set; }

        /// <summary>
        /// Field validation using the [Slug] attribute
        /// </summary>
        [Slug]
        public static string? Slug { get; set; }

        /// <summary>
        /// Field validation using the [Percentage] attribute
        /// </summary>
        [Percentage]
        public static string? Percentage { get; set; }

        /// <summary>
        /// Field validation using the [UUID] attribute
        /// </summary>
        [UUID]
        public static string? Uuid { get; set; }

        /// <summary>
        /// Field validation using the [NonEmptyStrings] attribute
        /// </summary>
        [NonEmptyStrings]
        public static string? NonEmptyString { get; set; }

        /// <summary>
        /// Field validation using the [DigitsWithThousandsSeparator] attribute
        /// </summary>
        [DigitsWithThousandsSeparator]
        public static string? DigitsWithThousandsSeparator { get; set; }

        /// <summary>
        /// Field validation using the [MultilingualText] attribute
        /// </summary>
        [MultilingualText]
        public static string? MultilingualText { get; set; }

        /// <summary>
        /// Field validation using the [FloatingPointNumber] attribute
        /// </summary>
        [FloatingPointNumber]
        public static string? FloatingPointNumber { get; set; }

        /// <summary>
        /// Field validation using the [PositiveIntegersOnly] attribute
        /// </summary>
        [PositiveIntegersOnly]
        public static string? PositiveInteger { get; set; }

        /// <summary>
        /// Field validation using the [NegativeIntegersOnly] attribute
        /// </summary>
        [NegativeIntegersOnly]
        public static string? NegativeInteger { get; set; }
        /// <summary>
        /// Field validation using the [AlphaNumericWithSpaces] attribute
        /// </summary>
        [AlphaNumericWithSpaces]
        public static string? AlphaNumericWithSpaces { get; set; }

        /// <summary>
        /// Field validation using the [UppercaseOnly] attribute
        /// </summary>
        [UppercaseOnly]
        public static string? UppercaseOnly { get; set; }

        /// <summary>
        /// Field validation using the [LowercaseOnly] attribute
        /// </summary>
        [LowercaseOnly]
        public static string? LowercaseOnly { get; set; }

        /// <summary>
        /// Field validation using the [TwoDecimalFloatingPoint] attribute
        /// </summary>
        [TwoDecimalFloatingPoint]
        public static string? TwoDecimalFloatingPoint { get; set; }

        /// <summary>
        /// Field validation using the [USZipPlus4Code] attribute
        /// </summary>
        [USZipPlus4Code]
        public static string? UsZipPlus4Code { get; set; }

        /// <summary>
        /// Field validation using the [FilePath] attribute
        /// </summary>
        [FilePath]
        public static string? FilePath { get; set; }

        /// <summary>
        /// Field validation using the [HTMLComment] attribute
        /// </summary>
        [HTMLComment]
        public static string? HtmlComment { get; set; }

        /// <summary>
        /// Field validation using the [CreditCardExpirationDate] attribute
        /// </summary>
        [CreditCardExpirationDate]
        public static string? CreditCardExpiration { get; set; }

        /// <summary>
        /// Field validation using the [CanadianPostalCode] attribute
        /// </summary>
        [CanadianPostalCode]
        public static string? CanadianPostalCode { get; set; }

        /// <summary>
        /// Field validation example
        /// </summary>
        [HTMLColor]
        public static string? Html { get; set; }

        /// <summary>
        /// Field validation using the [EuropeanDate] attribute
        /// </summary>
        [EuropeanDate]
        public static string? DayEuFormat { get; set; }

        /// <summary>
        /// Field validation using the [Base64String] attribute
        /// </summary>
        [Base64String]
        public static string? Base64String { get; set; }

        /// <summary>
        /// Field validation using the [YouTubeVideoID] attribute
        /// </summary>
        [YouTubeVideoID]
        public static string? YouTubeVideoId { get; set; }

        /// <summary>
        /// Field validation using the [IPv4CIDRBlock] attribute
        /// </summary>
        [IPv4CIDRBlock]
        public static string? IpV4CidrBlock { get; set; }

        /// <summary>
        /// Field validation using the [TwitterUsername] attribute
        /// </summary>
        [TwitterUsername]
        public static string? TwitterUsername { get; set; }

        /// <summary>
        /// Field validation using the [InstagramUsername] attribute
        /// </summary>
        [InstagramUsername]
        public static string? InstagramUsername { get; set; }

        /// <summary>
        /// Field validation using the [LinkedInProfileURL] attribute
        /// </summary>
        [LinkedInProfileURL]
        public static string? LinkedInProfileURL { get; set; }

        /// <summary>
        /// Field validation using the [UUIDWithBraces] attribute
        /// </summary>
        [UUIDWithBraces]
        public static string? UuidWithBraces { get; set; }

        /// <summary>
        /// Press to validate all the form fields and execute and process the submission
        /// </summary>
        [DebuggerHidden] //Prevent debugging from breaking on invalid fields
        public static void Submit()
        {
            // NORE: For the non-static class, validation is done by passing "this" (the value of the class) as a parameter:
            // if (!UISupportGeneric.Util.ValidateClass(this, out var report))           
            if (!UISupportGeneric.Util.ValidateClass(typeof(FieldAttributes), out var report))
            {
                string ValidationErrorsLeteral = string.Join(Environment.NewLine, report.Select(kvp => $"{kvp.Key}: {kvp.Value}"));
                throw new Exception(ValidationErrorsLeteral);
            }

            // I put here the code that will be executed when the validation is successful!

        }

    }

}
