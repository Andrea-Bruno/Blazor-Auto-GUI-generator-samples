
using System.Diagnostics;
using System.Text.Json;

namespace InvoicesInCloudBackEnd.Panels
{
    /// <summary>
    /// Example of a form to fill in
    /// </summary>
    public class UserProfile
    {
        /// <summary>
        /// You are welcome
        /// </summary>
        public string Hello => (Gender == GenderType.Male ? "Mr. " : Gender == GenderType.Female ? "Miss " : "") + Name + " " + Surname;

        /// <summary>
        /// Your legal name
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Your maiden name,
        /// </summary>
        public string? Surname { get; set; }

        /// <summary>
        /// Possible selectable values ​​for gender
        /// </summary>
        public enum GenderType { Male, Female, Hermaphrodite, IPreferNotToSay, NotSpecified }

        /// <summary>
        /// Birth sex
        /// </summary>
        public GenderType Gender { get; set; } = GenderType.NotSpecified;

        /// <summary>
        /// Contact telephone number
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Enter your date of birth as per your identity document
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Declaration of civil liability
        /// </summary>
        public bool IConfirmThatAllDataIsCorrectAndReal { get; set; }

        /// <summary>
        /// Submit the form 
        /// </summary>
        /// <returns>Result of the operation</returns>
        [DebuggerHidden]
        public string ConfirmSubscription()
        {
            if (!IConfirmThatAllDataIsCorrectAndReal)
                throw new Exception("You must first confirm that the data is correct and real");
            if (string.IsNullOrEmpty(Name))
                throw new Exception("Omitted field: " + nameof(Name));
            if (string.IsNullOrEmpty(Surname))
                throw new Exception("Omitted field: " + nameof(Surname));
            string json = JsonSerializer.Serialize(this);
            File.WriteAllText(Name + Surname + ".json", json);
            return "Operation completed";
        }
    }
}
