using System.Diagnostics;

namespace FieldSetting.Panels
{
    /// <summary>
    /// Example of custom fields with a regular expression assigned as an attribute
    /// </summary>
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

        /// <summary>
        /// Press to validate all the form fields and execute and process the submission
        /// </summary>
        [DebuggerHidden] //Prevent debugging from breaking on invalid fields
        public void Submit()
        {
            if (!UISupportGeneric.Util.ValidateClass(this, out var report))
            {
                string ValidationErrorsLeteral = string.Join(Environment.NewLine, report.Select(kvp => $"{kvp.Key}: {kvp.Value}"));
                throw new Exception(ValidationErrorsLeteral);
            }

            // I put here the code that will be executed when the validation is successful!

        }

    }
}
